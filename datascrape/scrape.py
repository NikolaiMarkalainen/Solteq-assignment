import requests
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
    single_product_view = requests.get("https://www.cloetta.fi" + link)
    soup = BeautifulSoup(single_product_view.text, "html.parser")
    title = soup.find("h1", attrs={"class": "title"})
    
    custom_text = soup.find("div", attrs={"data-id": "0e6990d"}).get_text() # p, custom-attribute
    weight = soup.find("div", attrs={"data-id": "4944c47"}).getText() #p, custom-attribute
    code = soup.find("div", attrs={"data-id": "c64be7a"}).getText() #p, custom-attribute
    ingredients = soup.find("div", attrs={"data-id": "8ef774f"}).getText() #p, custom-attributes



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
            # if p tag is bold in table attribute this is a title
            if 'bold' in p.get('class', []) and 'table-attribute' in p.get('class', []):
                if index % 2 == 0:
                    table_name.append(p.get_text().strip())
                else:
                    table_value.append(p.get_text().strip())
                #indent details
            if 'indent' in p.get('class', []):
                table_indents.append(p.get_text().strip())

        nutritional_info = []
        for name, value in zip(table_name, table_value):
            nutritional_info.append({"name": name, "value": value})

    product_features = soup.find("ul", attrs={"class": "product-features"})
    product_data = {
        "title": title,
        "custom_text": custom_text, 
        "weght": weight, 
        "code": code, 
        # "ingredients": ingredients, 
        # "nutritional_details": nutritional_details,
        # "product_features": product_features
    }
    product_list.append(product_data)
    print(table_name)
    print(table_value)
    print(table_indents)
