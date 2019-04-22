# NPlaylist

[![Build status](https://ci.appveyor.com/api/projects/status/x5nfnkd2vawcmi89/branch/master?svg=true)](https://ci.appveyor.com/project/aivascu/nplaylist/branch/master)
[![Build Status](https://enaivascu.visualstudio.com/NPlaylist/_apis/build/status/nplaylist-lib-ci?branchName=master)](https://enaivascu.visualstudio.com/NPlaylist/_build/latest?definitionId=4&branchName=master)
[![Code quality](https://www.codefactor.io/repository/github/nplaylist/nplaylist/badge?style=flat)](https://www.codefactor.io/repository/github/nplaylist/nplaylist)

## Contents
  1. [Quick example](#Quick-example)

## Quick example
In this example, we convert an Asx playlist into Wpl and Xspf.

~~~xml
<asx version="3.0">
  <title>Sample playlist</title>

  <entry>
    <title>Song 1</title>
    <ref href="http://example.com/announcement.wma" />
    <param name="aParameterName" value="aParameterValue" />
  </entry>

  <entry>
    <title>Song 2</title>
    <ref href="http://example.com:8080" />
    <author>Some author</author>
    <copyright>©2005 Example.com</copyright>
  </entry>

</asx>
~~~


~~~C#
string asxPlaylistStr = // Get the above xml

var asxDeserializer = new AsxDeserializer();
AsxPlaylist asxPlaylist = asxDeserializer.Deserialize(asxPlaylistStr);

asxPlaylist.Add(new AsxItem("some/local/path.mp3")
{
  Author = "M. D. Luffy"
});

asxPlaylist.Title = "O. P.";

var wplPlaylist = new WplPlaylist(asxPlaylist);
var wplSerializer = new WplSerializer();
string searializedWplPlaylist = wplSerializer.Serialize(wplPlaylist);

var xspfPlaylist = new XspfPlaylist(wplPlaylist);
var xspfSerializer = new XspfSerializer();
string serializedXspfPlaylist = xspfSerializer.Serialize(xspfPlaylist);
~~~

searializedWplPlaylist:
~~~xml
<?wpl version="1.0"?>
<smil>
    <head>
      <title>O. P.</title>
    </head>
    <body>
        <seq>
            <media src="http://example.com/announcement.wma"/>
            <media src="http://example.com:8080"/>
            <media src="some/local/path.mp3"/>
        </seq>
    </body>
</smil>
~~~


serializedXspfPlaylist:
~~~xml
<?xml version="1.0" encoding="UTF-8"?>
<playlist version="1" xmlns="http://xspf.org/ns/0/">
  <trackList>
    <track>
      <title>Song 1</title>
      <location>http://example.com/announcement.wma</location>
    </track>
    <track>
      <title>Song 2</title>
      <location>http://example.com:8080</location>
    </track>
    <track>
      <title>M. D. Luffy</title>
      <location>some/local/path.mp3</location>
    </track>
  </trackList>
</playlist>
~~~
