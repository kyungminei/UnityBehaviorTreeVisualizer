# Changelog

All notable changes to this package will be documented in this file.

## [0.1.2] - 9-27-2020

* Fixed a bug that was causing the layout to be drawn incorrectly (no spaces between sections).

## [0.1.1] - 9-23-2020

* Added support for 2019.4 LTS for the sample projects
* [#9](https://github.com/Yecats/UnityBehaviorTreeVisualizer/issues/9) Settings file no longer loses data on editor restart.
* [#6](https://github.com/Yecats/UnityBehaviorTreeVisualizer/issues/6) Settings Window - Checking the decorator checkbox now disables the color field.
* [#4](https://github.com/Yecats/UnityBehaviorTreeVisualizer/issues/4) Behavior Tree now works when scene stops/starts.
* [#1](https://github.com/Yecats/UnityBehaviorTreeVisualizer/issues/1) Action nodes that have decorators now properly highlight.
* Decorator nodes with `StatusReason` messages now display their messages.
* Nodes now show their last drawn state when first launching the Behavior Tree Window.
* Fix null ref issue when icons are missing.
* Settings file now contains default values for highlight, dim, and color fields.

## [0.1.0] - 09-15-2020

### This is the first release of _Behavior Tree Visualizer.

* Draws a graph representation of your behavior tree implementation
* Highlights nodes as they are running and surfaces StatusReason message
* Several style customization settings
* Standard behavior tree nodes for new implementation
* Sample project demonstrating behavior tree usage