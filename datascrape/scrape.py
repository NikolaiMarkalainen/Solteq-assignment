import requests
import csv
from bs4 import BeautifulSoup

scrape_page = requests.get("https://www.cloetta.fi/brandit/lakerol-dents/")
soup = BeautifulSoup(scrape_page.text, "html.parser")
# Find all a tags that lead to product information

links = soup.findAll("a",attrs={"class": "product-link"})

hrefs = []

for link in links:
    href = link.get("href")
    if href:
        hrefs.append(href)

print(hrefs)

product_list = []
for link in hrefs:
    single_product_view = requests.get("https://www.cloetta.fi/" + link)
    single_product_view.encoding = "utf-8"
    soup = BeautifulSoup(single_product_view.text, "html.parser")
    title = soup.find("h1", attrs={"class": "title"}).get_text(strip=True)
    
    custom_text = soup.find("div", attrs={"data-id": "0e6990d"}).get_text(strip=True) # p, custom-attribute
    weight = soup.find("div", attrs={"data-id": "7941bdc"}).find("p", attrs={"p", "weight"}).get_text(strip=True) #p, custom-attribute
    warning_label = soup.find("div", attrs={"data-id": "4944c47"}).find("p").get_text(strip=True) 
    code = soup.find("div", attrs={"data-id": "c64be7a"}).get_text(strip=True) #p, custom-attribute
    ingredients = soup.find("div", attrs={"data-id": "8ef774f"}).get_text(strip=True) #p, custom-attributes



    nutritional_details_div = soup.find("div", attrs={"class": "nutritional-table"})
    if nutritional_details_div:

        nutritional_p_tags = nutritional_details_div.find_all("p", class_="table-attribute")

        # find p tags with table-attribute keyword once we found nutritional table
        generic_table_array = [] # hold numerical and name
        table_value = []  # value numerical
        table_name = []  # table name
        table_indents = [] # additional details of product

        table_parent = [] # hold the table contents 

        for index, p in enumerate(nutritional_p_tags):
            # First is always field name and second is value for the field
            if index % 2 == 0:
                table_name.append(p.get_text().strip())
            else:
                table_value.append(p.get_text().strip())

        nutritional_info = []

        for name, value in zip(table_name, table_value):
            nutritional_info.append({"field":name, "value": value})

    product_features_list = soup.find_all("ul", attrs={"class": "product-features"})

    product_contains = []
    if(len(product_features_list) > 0):
        for li in product_features_list[0].find_all("li"):
            product_contains.append(li.get_text(strip=True))
    
    product_does_not_contain = []

    if(len(product_features_list) > 1):
        for li in product_features_list[1].find_all("li"):
            product_does_not_contain.append(li.get_text(strip=True))
    print(nutritional_info)
    product_data = {
        "title": title,
        "custom_text": custom_text, 
        "weight": weight, 
        "warning": warning_label,
        "code": code, 
        "ingredients": ingredients, 
        "nutritional_details": nutritional_info,
        "product_contains": product_contains,
        "product_does_not_contain": product_does_not_contain
    }
    product_list.append(product_data)

csv_file = "products.csv"
csv_columns = [ "title", "custom_text", "weight", "warning", "code", "ingredients", "nutritional_details", "product_contains", "product_does_not_contain"]

try:
    with open (csv_file, mode="w", newline="", encoding="utf-8") as csvfile:
        writer = csv.DictWriter(csvfile, quoting=csv.QUOTE_MINIMAL ,fieldnames=csv_columns)
        writer.writeheader()
        for product in product_list:
            product["nutritional_details"] = str(product["nutritional_details"])
            product["product_contains"] = ", ".join(product["product_contains"])
            product["product_does_not_contain"] = ", ".join(product["product_does_not_contain"])
            writer.writerow(product)
    print(f"Data successfully exported to {csv_file}")
except Exception as e:
    print(f"Error writing to CSV file: {e}")