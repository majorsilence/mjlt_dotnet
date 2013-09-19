mjlt_dotnet
===========

mjlt (major link tool) dot net api is a library wrapping the mjlt.biz site.  The site is used to create short urls.


# Examples

# Create a new short url
```c#
var c = new LibMjlt.Mjlt();
c.UserAgent = "Your Program Name";
string shortUrl = c.Create("http://www.some-example-website.com/some-long-very-very-long-page-on-the-site.html");
```


## Retrieve 11 random sites

```c#
var c = new LibMjlt.Mjlt();
c.UserAgent = "Your Program Name";
var r = c.GetRandomSites(11);
foreach (var site in r)
{
  System.Console.WriteLine(site.Code);
  System.Console.WriteLine(site.Url);
}
```

## Retrieve 10 most popular sites
```c#
var c = new LibMjlt.Mjlt();
c.UserAgent = "Your Program Name";
var top10 = c.GetTopTenSites();

foreach (var site in top10)
{
    System.Console.WriteLine(site.Count);
    System.Console.WriteLine(site.Url);
    System.Console.WriteLine(site.Url_Id);
}
```

## Retrieve 50 most popular sites
```c#
var c = new LibMjlt.Mjlt();
c.UserAgent = "Your Program Name";
var top50 = c.GetTopFiftySites();

foreach (var site in top50)
{
  System.Console.WriteLine(site.Count);
  System.Console.WriteLine(site.Url);
  System.Console.WriteLine(site.Url_Id);
}
```

## Retrieve 100 most popular sites
```c#
var c = new LibMjlt.Mjlt();
c.UserAgent = "Your Program Name";
var top100 = c.GetTopOneHundredSites();

foreach (var site in top100)
{
  System.Console.WriteLine(site.Count);
  System.Console.WriteLine(site.Url);
  System.Console.WriteLine(site.Url_Id);
}
```
