from pathlib import Path
import scrapy
from scrapy.spiders import Spider


class QuotesSpider(Spider):
    name = "quotes"

    def start_requests(self):
        urls = [
            'https://en.wikipedia.org/wiki/Timeline_of_the_21st_century',
            'https://en.wikipedia.org/wiki/Timeline_of_the_20th_century',
        ]
        for url in urls:
            yield scrapy.Request(url=url, callback=self.parse)

    def parse(self, response):
        page = response.url.split("/")[-2]
        filename = f'events-{page}.html'
        Path(filename).write_bytes(response.body)
        self.log(f'Saved file {filename}')