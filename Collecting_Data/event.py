import json


def create_json_object(name, year, description, countries):
    contents = dict(name=name, beginYear=year, endYear=year, description=description, countries=countries)
    return json.dumps(contents)


class Event:
    def __init__(self, name, year, description, countries):
        self.json_string = create_json_object(name, int(year), description, countries)

    def call_post_api(self):
        print(self.json_string)

