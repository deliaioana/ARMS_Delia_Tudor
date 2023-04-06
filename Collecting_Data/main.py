import re

from list_of_events import ListOfEvents
from event import Event

EVENTS_DATA = ListOfEvents()
EXPECTANCY_DATA = []


def get_mentioned_countries(description):
    countries = []

    with open('countries.txt') as f:
        for country in f:
            country.replace('\n', '')
            if country in description:
                countries.append(dict(name=country))

    return countries


def gather_events_data_from_file(file_name):
    with open(file_name, encoding="utf8") as f:
        year = None
        event_counter = 0

        for line in f:
            if '<h3>' in line:
                match = re.match(r'.title=\"(\d+)\".', line)
                print('before match')
                if match:
                    print('match')
                    year = match.group(1)
                    event_counter = 0

            if year:
                if '<li>' in line:
                    event_counter += 1
                    content = re.findall(r'>(.)<', line)
                    description = ' '.join(content)
                    countries = get_mentioned_countries(description)

                    name = f'{year} Event {event_counter}'
                    event = Event(name, year, description, countries)
                    EVENTS_DATA.add_event(event)


def gather_events_data():
    for year in range(15, 21):
        file_name = f'spider/spider/Timeline_of_the_{str(year)}th_century.html'
        gather_events_data_from_file(file_name)
    gather_events_data_from_file(f'spider/spider/Timeline_of_the_21st_century.html')


def gather_life_expectancy_data():
    pass


def gather_data():
    gather_events_data()
    gather_life_expectancy_data()


def call_post_api_for_events_data():
    EVENTS_DATA.call_post_api_for_events()


def call_post_api_for_expectancy_data():
    pass


def populate_database_with_data():
    call_post_api_for_events_data()
    call_post_api_for_expectancy_data()


def run():
    gather_data()
    populate_database_with_data()


run()
