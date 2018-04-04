# Notes

- Parse initial list of sites returned  
    1. With all URLs containing film-info and cinema
    2. Match unique # and films
    3. Create showing object
    4. If cinema is new, create; else assign existing
    5. If film title is new, create; else assign existing

- pull HAG part into ISiteReader, mock, returning HtmlDocument
- SiteChecker becomes the scraping part, taking HtmlDocument returned from SiteReader

- SiteChecker - if film title not set on showing, get film title from page, add into film object
- SiteChecker - pull out time nodes, send to ShowingBuilder
- ShowingBuilder creates showing for each node

    
- For each showing object, navigate to  
	https://curzoncinemas.com/cinema/[ID]/film-info/[film-slug]

- For each page, for each date and time, create showing

- Return List of showings

- Print these out as appropriate


## Test Output


        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139163" class="filmTimeItem" data-film-list-item-session-exp="">3:40 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139168" class="filmTimeItem" data-film-list-item-session-exp="">5:45 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139154" class="filmTimeItem" data-film-list-item-session-exp="">8:30 PM</a>
				</li>
			</ul>
			
    