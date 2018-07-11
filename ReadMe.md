# Sliding HUD Indicator

<img src="ScreenShots/example.gif"  height="128" />

This project is home to Sliding HUD indicator. For example, if a player collects money, a customizable strip will slide from out of view, show the change, and then slide back out of view.




## Getting Started

Clone or download the project. This is a learning project and not a package you can import.

### Prerequisites

Unity 2018.1+




### Todo / Roadmap
* Convert Sliding Object into a reusable prefab.
* Choosing Left or Right Screen Aligned Slide
* Different Modes: Static, Disposable

For Example:
* Static would be like a money counter. This would stay in view until the money counter is no longer being updated. Then slide out of view.
* Disposable would be collecting objects (Fish, Flowers, Whatever) and as you collect, the sliders would stack on top of each other, with the oldest sliding out first.




## Known Bugs
* Spamming the Add/Remove will cause the Slider Object to disappear instantly when the update is complete, instead of sliding back out.


## Contributing

Please feel free to contribute!


## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details


