# Burglar of Babylon

## Installation instructions

Because Burglar of Babylon uses very early version of Rogue Sheep, it requires a little special treatment: in particular, the git repo for the Rogue Sheep needs to be cloned side-by-side with the BoB, into the folder with the name 'RogueSheep'; this way BoB will be able to find that project and build against it.

For example:
```
my-dev-folder
    -> BurglarOfBabylon
        -> BurglarOfBabylon.csproj
    -> RogueSheep
        -> RogueSheep.csproj
```

This is not great, but I don't really want to publish NuGet package of Rogue Sheep yet; sorry!
