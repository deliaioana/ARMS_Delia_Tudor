import json

import requests
import urllib3

urllib3.disable_warnings()


def create_json_object(year, country, age):
    contents = dict(year=year, countryName=country, maleLifeExpectancy=age, femaleLifeExpectancy=age)
    return json.loads(json.dumps(contents))


class Expectancy:
    def __init__(self, year, country, age):
        self.json_string = create_json_object(int(year), country, float(age))

    def call_post_api(self):
        x = requests.post(json=self.json_string, url='https://localhost:7001/api/LifeExpectancies', verify=False)
        print(x.status_code, x.text)

    def print_expectancy(self):
        print(self.json_string)
