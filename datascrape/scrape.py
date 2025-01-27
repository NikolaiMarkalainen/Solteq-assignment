import requests
import csv
import json
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

def fieldNameToJsonProp(field_name):
    match field_name:
        case "Energia":
            return "energy"
        case "Rasva":
            return "fat"
        case "josta tyydyttynyttä":
            return "saturated_fat"
        case "Hiilihydraatit":
            return "carbohydrates"
        case "josta sokereita":
            return "sugars"
        case "josta polyoleja":
            return "polyols"
        case "Proteiini":
            return "protein"
        case "Suola":
            return "salt"
        case _:
            return None
        
def formatToArray(malformattedArray):
    if isinstance(malformattedArray, list):
        quoted_variables = [f'"{variable}"' for variable in malformattedArray]
    elif isinstance(malformattedArray, str):
        variables = [variable.strip() for variable in malformattedArray.split(",")]
        quoted_variables = [f'"{variable}"' for variable in variables]
    else:
        return "{}"
    
    formattedArray = "{" + ", ".join(quoted_variables) + "}"
    return formattedArray

nutrition_list = []
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
            nutritional_info.append({fieldNameToJsonProp(name): value})
    nutritional_info.append({"product_id": code})
    product_features_list = soup.find_all("ul", attrs={"class": "product-features"})

    product_contains = []
    if(len(product_features_list) > 0):
        for li in product_features_list[0].find_all("li"):
            product_contains.append(li.get_text(strip=True))
    
    product_does_not_contain = []

    if(len(product_features_list) > 1):
        for li in product_features_list[1].find_all("li"):
            product_does_not_contain.append(li.get_text(strip=True))
    product_data = {
        "title": title,
        "custom_text": custom_text, 
        "weight": weight, 
        "warning": warning_label,
        "code": code, 
        "ingredients": ingredients, 
        "product_contains": formatToArray(product_contains),
        "product_does_not_contain": formatToArray(product_does_not_contain)
    }


    transformed_nutrition_info = {}
    for item in nutritional_info:
        transformed_nutrition_info.update(item)

    product_list.append(product_data)
    nutrition_list.append(transformed_nutrition_info)
csv_file = "products.csv"
csv_columns = [ "title", "custom_text", "weight", "warning", "code", "ingredients", "product_contains", "product_does_not_contain"]

print(nutrition_list)
try:
    with open (csv_file, mode="w", newline="", encoding="utf-8") as csvfile:
        writer = csv.DictWriter(csvfile, quoting=csv.QUOTE_MINIMAL ,fieldnames=csv_columns)
        writer.writeheader()
        for product in product_list:
            writer.writerow(product)
    print(f"Data successfully exported to {csv_file}")
except Exception as e:
    print(f"Error writing to CSV file: {e}")

nutrition_csv_file = "nutrition.csv"
nutrition_csv_columns = ["product_id", "calories", "fat", "saturated_fat", "carbohydrates", "sugars", "polyols", "protein", "salt"]


try:
    with open (nutrition_csv_file, mode="w", newline="", encoding="utf-8") as csvfile:
        writer = csv.DictWriter(csvfile, quoting=csv.QUOTE_MINIMAL, fieldnames=nutrition_csv_columns)
        writer.writeheader()
        for nutrition_data in nutrition_list:
            transformed_data = {
            "calories": nutrition_data.get("energy", ""),
            "fat": nutrition_data.get("fat", ""),
            "saturated_fat": nutrition_data.get("saturated_fat", ""),
            "carbohydrates": nutrition_data.get("carbohydrates", ""),
            "sugars": nutrition_data.get("sugars", ""),
            "polyols": nutrition_data.get("polyols", ""),
            "protein": nutrition_data.get("protein", ""),
            "salt": nutrition_data.get("salt", ""),
            "product_id": nutrition_data.get("product_id", "")
            }
            writer.writerow(transformed_data)
    print(f"Data successfully exported to {nutrition_csv_file}")
except Exception as e:
    print(f"Error writing to CSV: {e}")