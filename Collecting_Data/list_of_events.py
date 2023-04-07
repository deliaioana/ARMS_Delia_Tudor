class ListOfEvents:
    def __init__(self):
        self.events = []

    def add_event(self, event):
        self.events.append(event)

    def call_post_api_for_events(self):
        for event in self.events:
            event.call_post_api()

    def print_events(self):
        for event in self.events:
            event.print_event()
