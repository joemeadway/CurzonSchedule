# Notes

- Parse initial list of sites returned  
    1. With all URLs containing film-info and cinema
    2. Match unique # and films
    3. Create showing object
    4. If cinema is new, create; else assign existing
    5. If film title is new, create; else assign existing
    
- For each showing object, navigate to  
    https://curzoncinemas.com/[cinema ID]/237/film-info/[film title]

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
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139183" class="filmTimeItem" data-film-list-item-session-exp="">2:45 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139184" class="filmTimeItem" data-film-list-item-session-exp="">6:00 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139173" class="filmTimeItem" data-film-list-item-session-exp="">8:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139202" class="filmTimeItem" data-film-list-item-session-exp="">2:00 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139203" class="filmTimeItem" data-film-list-item-session-exp="">5:15 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139191" class="filmTimeItem" data-film-list-item-session-exp="">8:10 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139220" class="filmTimeItem" data-film-list-item-session-exp="">3:00 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139221" class="filmTimeItem" data-film-list-item-session-exp="">6:10 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139210" class="filmTimeItem" data-film-list-item-session-exp="">8:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139256" class="filmTimeItem" data-film-list-item-session-exp="">3:20 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139246" class="filmTimeItem" data-film-list-item-session-exp="">8:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139239" class="filmTimeItem" data-film-list-item-session-exp="">2:00 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139241" class="filmTimeItem" data-film-list-item-session-exp="">5:20 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139260" class="filmTimeItem" data-film-list-item-session-exp="">8:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6062720" class="filmTimeItem" data-film-list-item-session-exp="">10:50 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062719" class="filmTimeItem" data-film-list-item-session-exp="">1:10 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062718" class="filmTimeItem" data-film-list-item-session-exp="">3:30 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062721" class="filmTimeItem" data-film-list-item-session-exp="">6:50 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062722" class="filmTimeItem" data-film-list-item-session-exp="">9:10 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6062717" class="filmTimeItem" data-film-list-item-session-exp="">12:15 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062713" class="filmTimeItem" data-film-list-item-session-exp="">2:00 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062714" class="filmTimeItem" data-film-list-item-session-exp="">4:20 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062715" class="filmTimeItem" data-film-list-item-session-exp="">6:40 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062716" class="filmTimeItem" data-film-list-item-session-exp="">9:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6062693" class="filmTimeItem" data-film-list-item-session-exp="">11:30 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062694" class="filmTimeItem" data-film-list-item-session-exp="">1:50 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062695" class="filmTimeItem" data-film-list-item-session-exp="">4:10 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062696" class="filmTimeItem" data-film-list-item-session-exp="">6:30 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062697" class="filmTimeItem" data-film-list-item-session-exp="">8:50 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6062698" class="filmTimeItem" data-film-list-item-session-exp="">11:50 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062699" class="filmTimeItem" data-film-list-item-session-exp="">2:10 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062700" class="filmTimeItem" data-film-list-item-session-exp="">4:30 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062701" class="filmTimeItem" data-film-list-item-session-exp="">6:50 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062702" class="filmTimeItem" data-film-list-item-session-exp="">9:10 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6062709" class="filmTimeItem" data-film-list-item-session-exp="">12:10 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062710" class="filmTimeItem" data-film-list-item-session-exp="">2:30 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062708" class="filmTimeItem" data-film-list-item-session-exp="">4:50 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062711" class="filmTimeItem" data-film-list-item-session-exp="">6:50 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062712" class="filmTimeItem" data-film-list-item-session-exp="">9:10 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6062703" class="filmTimeItem" data-film-list-item-session-exp="">11:10 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062704" class="filmTimeItem" data-film-list-item-session-exp="">1:30 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062705" class="filmTimeItem" data-film-list-item-session-exp="">3:50 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6062706" class="filmTimeItem" data-film-list-item-session-exp="">6:10 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139240" class="filmTimeItem" data-film-list-item-session-exp="">9:10 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
    				<span class="filmTimeItem Expired" data-film-list-item-session-exp="">10:40 AM</span>
				</li>
				<li>
			        	<a href="/booking/237/6139153" class="filmTimeItem" data-film-list-item-session-exp="">6:15 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139169" class="filmTimeItem" data-film-list-item-session-exp="">11:10 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139171" class="filmTimeItem" data-film-list-item-session-exp="">3:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139187" class="filmTimeItem" data-film-list-item-session-exp="">11:00 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139189" class="filmTimeItem" data-film-list-item-session-exp="">6:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139206" class="filmTimeItem" data-film-list-item-session-exp="">11:15 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139208" class="filmTimeItem" data-film-list-item-session-exp="">3:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139243" class="filmTimeItem" data-film-list-item-session-exp="">11:15 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139245" class="filmTimeItem" data-film-list-item-session-exp="">6:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139225" class="filmTimeItem" data-film-list-item-session-exp="">11:30 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139227" class="filmTimeItem" data-film-list-item-session-exp="">4:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Satellite" title="Satellite">Satellite</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/4760364" class="filmTimeItem" data-film-list-item-session-exp="Satellite">5:55 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139159" class="filmTimeItem" data-film-list-item-session-exp="">1:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139185" class="filmTimeItem" data-film-list-item-session-exp="">9:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139196" class="filmTimeItem" data-film-list-item-session-exp="">11:10 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139205" class="filmTimeItem" data-film-list-item-session-exp="">9:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139215" class="filmTimeItem" data-film-list-item-session-exp="">11:30 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139224" class="filmTimeItem" data-film-list-item-session-exp="">9:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139250" class="filmTimeItem" data-film-list-item-session-exp="">11:30 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139259" class="filmTimeItem" data-film-list-item-session-exp="">9:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139233" class="filmTimeItem" data-film-list-item-session-exp="">11:20 AM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139242" class="filmTimeItem" data-film-list-item-session-exp="">9:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139152" class="filmTimeItem" data-film-list-item-session-exp="">12:50 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139157" class="filmTimeItem" data-film-list-item-session-exp="">4:50 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139164" class="filmTimeItem" data-film-list-item-session-exp="">9:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139170" class="filmTimeItem" data-film-list-item-session-exp="">1:20 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139176" class="filmTimeItem" data-film-list-item-session-exp="">5:00 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139178" class="filmTimeItem" data-film-list-item-session-exp="">9:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139188" class="filmTimeItem" data-film-list-item-session-exp="">1:10 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139194" class="filmTimeItem" data-film-list-item-session-exp="">4:30 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139204" class="filmTimeItem" data-film-list-item-session-exp="">8:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139207" class="filmTimeItem" data-film-list-item-session-exp="">1:30 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139213" class="filmTimeItem" data-film-list-item-session-exp="">5:10 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139223" class="filmTimeItem" data-film-list-item-session-exp="">9:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139244" class="filmTimeItem" data-film-list-item-session-exp="">1:30 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139249" class="filmTimeItem" data-film-list-item-session-exp="">4:50 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139254" class="filmTimeItem" data-film-list-item-session-exp="">9:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139226" class="filmTimeItem" data-film-list-item-session-exp="">1:50 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139231" class="filmTimeItem" data-film-list-item-session-exp="">5:10 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139237" class="filmTimeItem" data-film-list-item-session-exp="">9:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139156" class="filmTimeItem" data-film-list-item-session-exp="">7:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139175" class="filmTimeItem" data-film-list-item-session-exp="">2:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139193" class="filmTimeItem" data-film-list-item-session-exp="">6:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139212" class="filmTimeItem" data-film-list-item-session-exp="">2:50 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139248" class="filmTimeItem" data-film-list-item-session-exp="">7:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139230" class="filmTimeItem" data-film-list-item-session-exp="">2:50 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139160" class="filmTimeItem" data-film-list-item-session-exp="">12:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139179" class="filmTimeItem" data-film-list-item-session-exp="">1:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139197" class="filmTimeItem" data-film-list-item-session-exp="">1:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139216" class="filmTimeItem" data-film-list-item-session-exp="">1:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139251" class="filmTimeItem" data-film-list-item-session-exp="">1:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139234" class="filmTimeItem" data-film-list-item-session-exp="">1:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139165" class="filmTimeItem" data-film-list-item-session-exp="">3:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139172" class="filmTimeItem" data-film-list-item-session-exp="">5:50 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139190" class="filmTimeItem" data-film-list-item-session-exp="">3:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139209" class="filmTimeItem" data-film-list-item-session-exp="">5:50 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139257" class="filmTimeItem" data-film-list-item-session-exp="">3:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139228" class="filmTimeItem" data-film-list-item-session-exp="">6:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Preview" title="Preview">Preview</li><li class="filmExpItem exp-Members" title="Members Priority Booking">Members Only Booking</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/5956857" class="filmTimeItem" data-film-list-item-session-exp="PreviewMembers">11:00 AM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-06"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6175316" class="filmTimeItem" data-film-list-item-session-exp="">6:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139161" class="filmTimeItem" data-film-list-item-session-exp="">3:20 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139167" class="filmTimeItem" data-film-list-item-session-exp="">9:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139180" class="filmTimeItem" data-film-list-item-session-exp="">4:15 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139181" class="filmTimeItem" data-film-list-item-session-exp="">6:40 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139182" class="filmTimeItem" data-film-list-item-session-exp="">9:10 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139198" class="filmTimeItem" data-film-list-item-session-exp="">4:00 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139199" class="filmTimeItem" data-film-list-item-session-exp="">6:20 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139200" class="filmTimeItem" data-film-list-item-session-exp="">8:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139217" class="filmTimeItem" data-film-list-item-session-exp="">4:20 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139218" class="filmTimeItem" data-film-list-item-session-exp="">6:40 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139222" class="filmTimeItem" data-film-list-item-session-exp="">9:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139252" class="filmTimeItem" data-film-list-item-session-exp="">4:20 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139253" class="filmTimeItem" data-film-list-item-session-exp="">6:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139235" class="filmTimeItem" data-film-list-item-session-exp="">4:20 PM</a>
				</li>
				<li>
			        	<a href="/booking/237/6139236" class="filmTimeItem" data-film-list-item-session-exp="">6:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
    				<span class="filmTimeItem Expired" data-film-list-item-session-exp="">10:30 AM</span>
				</li>
				<li>
			        	<a href="/booking/237/6139158" class="filmTimeItem" data-film-list-item-session-exp="">2:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139177" class="filmTimeItem" data-film-list-item-session-exp="">7:10 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139195" class="filmTimeItem" data-film-list-item-session-exp="">2:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139214" class="filmTimeItem" data-film-list-item-session-exp="">7:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139258" class="filmTimeItem" data-film-list-item-session-exp="">2:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139232" class="filmTimeItem" data-film-list-item-session-exp="">7:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139155" class="filmTimeItem" data-film-list-item-session-exp="">11:45 AM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139174" class="filmTimeItem" data-film-list-item-session-exp="">11:40 AM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139192" class="filmTimeItem" data-film-list-item-session-exp="">11:20 AM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139211" class="filmTimeItem" data-film-list-item-session-exp="">12:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139247" class="filmTimeItem" data-film-list-item-session-exp="">11:50 AM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139229" class="filmTimeItem" data-film-list-item-session-exp="">12:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139162" class="filmTimeItem" data-film-list-item-session-exp="">10:45 AM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139186" class="filmTimeItem" data-film-list-item-session-exp="">11:00 AM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139201" class="filmTimeItem" data-film-list-item-session-exp="">11:20 AM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139219" class="filmTimeItem" data-film-list-item-session-exp="">12:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139255" class="filmTimeItem" data-film-list-item-session-exp="">12:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp dn"></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6139238" class="filmTimeItem" data-film-list-item-session-exp="">11:15 AM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Satellite" title="Satellite">Satellite</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/4575488" class="filmTimeItem" data-film-list-item-session-exp="Satellite">7:15 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138751" class="filmTimeItem" data-film-list-item-session-exp="Bertha">4:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138752" class="filmTimeItem" data-film-list-item-session-exp="Bertha">4:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138753" class="filmTimeItem" data-film-list-item-session-exp="Bertha">5:50 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138754" class="filmTimeItem" data-film-list-item-session-exp="Bertha">8:45 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138755" class="filmTimeItem" data-film-list-item-session-exp="Bertha">6:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138756" class="filmTimeItem" data-film-list-item-session-exp="Bertha">2:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6041724" class="filmTimeItem" data-film-list-item-session-exp="Bertha">6:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6041725" class="filmTimeItem" data-film-list-item-session-exp="Bertha">8:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6041726" class="filmTimeItem" data-film-list-item-session-exp="Bertha">4:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138770" class="filmTimeItem" data-film-list-item-session-exp="Bertha">8:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138771" class="filmTimeItem" data-film-list-item-session-exp="Bertha">2:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138772" class="filmTimeItem" data-film-list-item-session-exp="Bertha">4:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138773" class="filmTimeItem" data-film-list-item-session-exp="Bertha">6:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-03-31"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138758" class="filmTimeItem" data-film-list-item-session-exp="Bertha">2:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138759" class="filmTimeItem" data-film-list-item-session-exp="Bertha">2:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138760" class="filmTimeItem" data-film-list-item-session-exp="Bertha">2:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138761" class="filmTimeItem" data-film-list-item-session-exp="Bertha">8:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138762" class="filmTimeItem" data-film-list-item-session-exp="Bertha">4:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-01"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138764" class="filmTimeItem" data-film-list-item-session-exp="Bertha">6:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-03"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138765" class="filmTimeItem" data-film-list-item-session-exp="Bertha">4:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-05"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138766" class="filmTimeItem" data-film-list-item-session-exp="Bertha">8:40 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-02"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138768" class="filmTimeItem" data-film-list-item-session-exp="Bertha">8:00 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-04"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6138769" class="filmTimeItem" data-film-list-item-session-exp="Bertha">2:20 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-06"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6041728" class="filmTimeItem" data-film-list-item-session-exp="Bertha">6:30 PM</a>
				</li>
			</ul>
			
    

        <div class="filmItemDate" data-dateformat="2018-04-06"></div>

            <ul class="filmExp "><li class="filmExpItem exp-Bertha" title="Bertha Dochouse">Bertha DocHouse (5 minutes of trailers only)</li></ul>
			<ul class="filmTimes">
				<li>
			        	<a href="/booking/237/6118168" class="filmTimeItem" data-film-list-item-session-exp="Bertha">8:30 PM</a>
				</li>
			</ul>
			
    
