class ListOfExpectancies:
    def __init__(self):
        self.expectancies = []

    def add_expectancy(self, expectancy):
        self.expectancies.append(expectancy)

    def call_post_api_for_expectancies(self):
        for expectancy in self.expectancies:
            expectancy.call_post_api()

    def print_expectancies(self):
        for expectancy in self.expectancies:
            expectancy.print_expectancy()
