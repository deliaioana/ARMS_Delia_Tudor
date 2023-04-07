import json
import re
import pandas as pd
import requests

from list_of_events import ListOfEvents
from event import Event

from list_of_expectancies import ListOfExpectancies
from expectancy import Expectancy

EVENTS_DATA = ListOfEvents()
EXPECTANCY_DATA = ListOfExpectancies()


def get_mentioned_countries(description):
    countries = []

    with open('countries.txt') as f:
        for country in f:
            country = country.replace('\n', '')
            if country in description:
                countries.append(dict(name=country))

    return countries


def gather_events_data_from_recent_files(file_name):
    with open(file_name, encoding='utf8') as f:
        year = None
        event_counter = 0

        for line in f:
            if '<h3>' in line:
                match = re.match(r'.*id=\"(\d+)\".*', line)
                if match:
                    year = match.group(1)
                    event_counter = 0

            if year:
                if '<li>' in line:
                    event_counter += 1

                    content = re.findall(r'>(.*?)<', line)
                    description = ''.join(content)
                    countries = get_mentioned_countries(description)

                    name = f'{year} Event {event_counter}'
                    event = Event(name, year, description, countries)
                    EVENTS_DATA.add_event(event)


def gather_events_data_from_old_files(file_name):
    with open(file_name, encoding='utf8') as f:
        year = None
        event_counter = 0

        for line in f:
            match = re.match(r'.*title=\"(\d+)\".*', line)
            if match:
                year = match.group(1)
                event_counter = 0

            if year:
                if '<li>' in line:
                    event_counter += 1

                    content = re.findall(r'>(.*?)<', line)
                    description = ''.join(content)
                    countries = get_mentioned_countries(description)

                    name = f'{year} Event {event_counter}'
                    event = Event(name, year, description, countries)
                    EVENTS_DATA.add_event(event)
                    year = None


def gather_events_data():
    for year in range(15, 20):
        file_name = f'spider/spider/Timeline_of_the_{str(year)}th_century.txt'
        gather_events_data_from_old_files(file_name)

    gather_events_data_from_recent_files(f'spider/spider/Timeline_of_the_20th_century.txt')
    gather_events_data_from_recent_files(f'spider/spider/Timeline_of_the_21st_century.txt')


def gather_life_expectancy_data(file_name):
    with open(file_name) as f:
        for line in f:
            data = line[:-1].split(',')

            if len(data) == 4:
                print(data)
                country = data[0]
                year = int(data[2])
                age = float(data[3])

                expectancy = Expectancy(year, country, age)
                EXPECTANCY_DATA.add_expectancy(expectancy)


def gather_data():
    gather_events_data()
    gather_life_expectancy_data('life-expectancy.csv')


def call_post_api_for_events_data():
    EVENTS_DATA.call_post_api_for_events()


def call_post_api_for_expectancy_data():
    EXPECTANCY_DATA.call_post_api_for_expectancies()


def populate_database_with_data():
    call_post_api_for_events_data()
    call_post_api_for_expectancy_data()


def get_events_csv():
    response = requests.get(url='https://localhost:7001/api/Events', verify=False)
    json_string = str(json.dumps(response.json()))
    df = pd.read_json(json_string)
    df.to_csv('events.csv')


def get_expectancies_csv():
    response = requests.get(url='https://localhost:7001/api/LifeExpectancies', verify=False)
    json_string = str(json.dumps(response.json()))
    df = pd.read_json(json_string)
    df.to_csv('expectancies.csv')


def get_csv_files():
    get_events_csv()
    get_expectancies_csv()


def run():
    # gather_data()
    # populate_database_with_data()
    get_csv_files()


run()
