# PhisherTank

[![CodeFactor](https://www.codefactor.io/repository/github/thexds/phishertank/badge)](https://www.codefactor.io/repository/github/thexds/phishertank)
[![Issues](https://img.shields.io/github/issues/TheXDS/PhisherTank)](https://github.com/TheXDS/PhisherTank/issues)
[![MIT](https://img.shields.io/github/license/TheXDS/PhisherTank)](https://mit-license.org/)

PhisherTank is a tool that will flood a phishing site with real looking (yet false) data, in the hopes that any victim could be blended into the fake data and not be found by the phisher. If this tool is left running continuously, there would also be the benefit of consuming database storage on the phishing site, which I hope will act as a deterrent for them to keep the site up.

This tool came to be due to slow response from some hosting providers to stop such attacks, and because I was bored for a few days.

Because of the bespoke nature of some of these sites, attacks must be tailored and implemented specifically for the target.

As of right now, there's two phishing sites supported.

- PHP.Berangkat
- PHP.liveblog365.A (Microsotf) (note the mispelling, there was another simmilar site with slight differences, but the site went down and silly me... I deleted the whole attack, but still. This is variant A)
- PHP.liveblog365.B (Bancatlan) (slightly more advanced, pretends to be a Honduran Bank, includes some advanced telemetry libary to presumably, keep track of resources downloaded by victims)

I came up with these names sort-of the same way an anti-virus company would come with theirs.

I'll clean it up someday. I'll eventually add command line arguments to allow it to use a specific attack over an arbitrary URL, and setting up the timeouts, threads and some other values that I find useful.

Note: This tool is not intended to be used to execute DDoS attacks, and I will not condone it (unless it's used to bring down phishing sites). It's for you to look at, and maybe execute it for your own amusement.

In the extremely unlike scenario that things like this tool become truly useful and important, consider leaving your star, and idk... helping me buy a coffee (I'll still need to set that up, GH sponsors does not work with banks here in my country)

## Building
PhisherTank can be built on any platform or CI environment supported by dotnet.

### Prerequisites
- [.Net SDK 6.0](https://dotnet.microsoft.com/) or higher.

### Build PhisherTank
```sh
dotnet build ./src/PhisherTank.sln
```
The resulting binaries will be in the `./Build/bin` directory.

## Contribute
If you think that Phishertank is useful, consider making a donation via
[PayPal](https://paypal.me/thexds), or contact me directly.

Sadly, I cannot offer any other donation methods, as my country (Honduras) is not supported on any platform. Not even PayPal supports donations per-se to people in Honduras, but at least I have an account there.
