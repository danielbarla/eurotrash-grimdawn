# Introduction

This is a quick document for people looking to understand or contribute to this
codebase.

My overall view on commenting code is that it should primarily at a class-
level.  These comments should explain the rationale behind the class, i.e the 
"why".  Most of the time, one should be able to give methods and variables a
descriptive enough name that further commenting will just duplicate things
and detract from readability.  Obviously where this is not the case, finer-
grained comments are allowed.

With that in mind, this document serves as an index of sorts, to give the 
reader an idea of the overall layout of the project, so that they know where to
jump in.


# Project Overview

The solution consists of four projects:

  + **.Core**: where most of the core data structures and logic reside.
  + **.Test**: a simple unit test project for .Core.
  + **.Import**: a utility which downloads and parses the Grim Dawn Wikia pages
    and produces a JSON.
  + **.WinFormsFrontEnd**: currently the main user front-end for the project.


# The .Core Project

The main namespaces here are (in logical order):

  + **Data**: simple DTOs representing the data imported from Wikia.
  + **Build**: collectively represent a Grim Dawn character build, though
    currently limited to Devotions.
  + **Analysis**: The majority of the logic built on the above two sets of data
    objects resides here.  This includes searching through the constellations,
	accumulating and validating (comparing) affinities, parsing and aggregating
	statistics bonuses.
   





