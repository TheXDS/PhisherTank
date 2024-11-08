# PhisherTank

[![CodeFactor](https://www.codefactor.io/repository/github/thexds/phishertank/badge)](https://www.codefactor.io/repository/github/thexds/phishertank)
[![Issues](https://img.shields.io/github/issues/TheXDS/PhisherTank)](https://github.com/TheXDS/PhisherTank/issues)
[![MIT](https://img.shields.io/github/license/TheXDS/PhisherTank)](https://mit-license.org/)

PhisherTank is a tool that will flood a phishing site with real looking (yet false) data, in the hopes that any victim could be blended into the fake data and not be found by the phisher. If this tool is left running continuously, there would also be the benefit of consuming database storage on the phishing site, which I hope will act as a deterrent for them to keep the site up.

This tool came to be due to slow response from some hosting providers to stop such attacks, and because I was bored for a few days.

Because of the bespoke nature of some of these sites, attacks must be tailored and implemented specifically for the target.

For a list of known phishing sites, go to [./src/PhisherTank/Attacks](https://github.com/TheXDS/PhisherTank/tree/main/src/PhisherTank/Attacks).

Note: This tool is not intended to be used to execute DDoS attacks, and I will not condone it (unless it's used to bring down phishing sites). It's for you to look at, and maybe execute it for your own amusement.

In the extremely unlike scenario that things like this tool become truly useful and important, consider leaving your star, and idk... helping me [buy a coffee](https://www.buymeacoffee.com/xdsxpsivx) perhaps.

## Command-Line reference
PhisherTank can be executed on any platform that supports `dotnet 8.0`. Take a look at the [Building prerequisites](#prerequisites) for more information on setting up your computer to run PhisherTank.

When running Phishertank from a terminal, you need to specify a command and a set of arguments. For more information, run `./PhisherTank --help` in the binary output directory.

### `attack` command
This is the command you want to use to initiate an attack loop. It will continously send requests to the phishing site you specify in the arguments.

The command is formatted as follows: `./PhisherTank attack <attackName> [options]` where: 
 - `attackName`: One of the available attacks. See the [`list` command](#list-command) for more information on how to get a list of available attacks.
 - `options`: Set of options used to customize the attack as follows:

Option           | Effect
---------------- | ------
`-t <timeout>`   | Specifies the desired timeout for all requests, in seconds. If not specified, the default value will be 30 seconds. An attack will mark an attempt as a failure after this timeout elapses.
`-T <threads>`   | Specifies the number of attack threads to generate. Defaults to the number of available CPUs on the system. Setting it higher allows for way more data to be sent to the phishing site, albeit it increases the chances of timing out (overloading the page).
`-s`             | Forces the attack to use https. You'll likely need to specify this one on most phishing sites on the modern internet. I might change the default behavior of this flag later.
`-d <dataGen>`   | Specifies the kind of data to send. On the current distribution of PhisherTank, there's a few supported [data generators](#supported-data-generators).
`-l <log level>` | Specifies a desired logging level (quiet\|summary\|threads\|detailed). Defaults to `Detailed`.

### `list` command
This command will output a list of all attacks that PhisherTank has built-in. Currently, PhisherTank does not support external attack libraries nor user-defined attacks, but I might consider adding support for it soon.

The command is formatted as follows: `./PhisherTank list` and will output something simmilar to this (as of 2024/03/07):
```
BacCredomaticCompras
BacDappLinePm
Bancatlan
Berangkat
DrexmHost
LinkPc
LiveDatePm
PantheonSite
Microsotf
Serviciosonline202323
TeteroProfe
Webcindario
HotSergu98
```

### `simulate` command
Simulates a set of actions to be performed while executing an attack, writing a log of the steps that would have been performed to standard output. This way, you can see if the attack matches what a phishing site would be expecting.

The command is formatted as follows: `./PhisherTank simulate <attackName>` where: 
 - `attackName`: One of the available attacks. See the [`list` command](#list-command) for more information on how to get a list of available attacks.

### `try` command
This command will execute a single attack workflow on the specified phishing site, and return a log of every step performed and whether or not it succeded. It's useful to determine if a phishing site might still be up, although some sites would not throw http errors if they're down, they'll just redirect to a landing site about the phishing site being blocked with a 3XX result... Including `POST` requests.

The command is formatted as follows: `./PhisherTank simulate <attackName>` where: 
 - `attackName`: One of the available attacks. See the [`list` command](#list-command) for more information on how to get a list of available attacks.

### Supported data generators
Generator name | Description
-------------- | -----------
Faux           | This generator will create real-looking (yet false) data. Information will include a random person name, age, email, credit card info, etc. Phisical addresses would be generated for any country in the world using the american format, for ex. 123 Some road name, building 123, some city, country.
Garbage        | This generator will fill all data fields with random characters from the entire Unicode-16 table. You might see Kanji, emoji, ASCII control characters, odd symbols, etc.
Test           | This generator will create "Test" data. All fields will be filled with "test" or ovbious test data.
Truckload      | Same as `Garbage`, but including about 64 KB of random bytes per field. Why 64 KB? It's large enough to cause trouble on SQL databases where a field may have a limited size, and small enough that most requests should not fail due to their size.
UsFaux         | Same as `Faux`, but restricting the physical address generation to US addresses. PhisherTank includes a small set of real US cities and states to use when generating this data to make it a bit more believable.

## Building
PhisherTank can be built on any platform or CI environment supported by dotnet.

### Prerequisites
- Either [.Net SDK 8.0](https://dotnet.microsoft.com/) or a later version with net8.0 targeting packs. (for building)
- [.Net Runtime 8.0](https://dotnet.microsoft.com/) if you only intend to run a pre-compiled version of PhisherTank (where would you get one is beyond me - I'm not distributing it as a compiled binary)

### Build PhisherTank
```sh
dotnet build ./src/PhisherTank.sln
```
The resulting binaries will be in the `./Build/bin` directory.

## Contribute
[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/W7W415UCHY)

If `PhisherTank` is useful to you, or if you're interested in donating to sponsor the project, feel free to to a donation via [PayPal](https://paypal.me/thexds), [Ko-fi](https://ko-fi.com/W7W415UCHY) or just contact me directly.

Sadly, I cannot offer other means of sending donations as of right now due to my country (Honduras) not being supported by almost any platform.
