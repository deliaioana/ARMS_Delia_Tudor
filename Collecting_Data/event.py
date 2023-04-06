import json

import requests
from requests.adapters import HTTPAdapter
import urllib3

urllib3.disable_warnings()


def create_json_object(name, year, description, countries):
    contents = dict(name=name, beginYear=year, endYear=year, description=description, countries=countries)
    return json.dumps(contents)


class Event:
    def __init__(self, name, year, description, countries):
        self.json_string = create_json_object(name, int(year), description, countries)

    def call_post_api(self):
        # session = requests.Session()
        # retry = Retry(connect=3, backoff_factor=0.5)
        # adapter = HTTPAdapter(max_retries=retry)
        # session.mount('http://', adapter)
        # session.mount('https://', adapter)
        #
        # url = 'https://localhost:7001/api/Events'
        # response = session.post(url, data=self.json_string)

        print(self.json_string)
        x = requests.post(json=self.json_string, url='https://localhost:7001/api/Events', verify=False)
        print(x.status_code, x.text)
