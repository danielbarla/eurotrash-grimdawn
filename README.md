# eurotrash-grimdawn

A simple companion utility for the (awesome) game [Grim Dawn](http://www.grimdawn.com/), to help with planning out Devotions.

![Main screenshot](http://i.imgur.com/vvWcNAY.png)

![Secondary screenshot](http://i.imgur.com/616CVWi.png?1)


# Why?

There's already an excellent utility called [GrimCalc](http://grimcalc.com/) for general build planning, however at the
time of writing (GD 1.0), Devotions support is / was quite basic.  I wanted to learn more about what Devotions options were 
available, without having to hover the mouse over each individual star.  Specific quality of life issues I wanted to solve:

  + Searching for constellations by name or effect
  + Aggregation (automatic adding up or stacking) of effects
  + Checking of build sanity / pre-requisites
  + Preservation of build order for future reference


# Import Tool

This main utility gets its database by downloading and parsing the GD wiki.  A separate utility exists to do this downloading,
parsing and exporting.  Users don't generally need to know about this separate utility, as the end result is packaged in the
release.


# Known Issues

  - Uses "data" from the Wiki, which could be incorrect or incomplete.
  - Support for incomplete constellation selection.  E.g. if you choose to take only 3 stars of a 5 star constellation, you 
    can confuse the application by taking the entire constellation again.
  - The "fix problems" button can only fix small gaps.  Some heuristics / early exiting would would be required to support
    larger searches (e.g. adding "Oleron" and expecting the utility to make a path to it for you).

# Ideas / WIP

  - Since shrines are static and well known, we could tag the build with where in the game you can expect to reach each step in
    in the build.  E.g. "Middle of Act II, Normal".
  - Skill abilities are currently not showing (though are parsed and detected).  It would be great if they could show, and if
    we could get details about the scale of their bonuses from level 1 to 20, etc.
  

