import json

import requests
import urllib3

urllib3.disable_warnings()


def create_json_object(name, year, description, countries):
    contents = dict(name=name, beginYear=year, endYear=year, description=description, countries=countries)
    return json.loads(json.dumps(contents))


class Event:
    def __init__(self, name, year, description, countries):
        self.json_string = create_json_object(name, int(year), description, countries)

    def call_post_api(self):
        x = requests.post(json=self.json_string, url='https://localhost:7001/api/Events', verify=False)
        print(x.status_code, x.text)
