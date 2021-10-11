# Ethereum Transaction Search

## Setting Up
1. The folder ClientApp is a standard Angular application, it can be speratedly hosted.
1. At the moment the client package management is handled by visual studio. We may use gulp or webpack to deploy in more customised way
1. Open a command line prompt, go to ClientApp folder and then run npm install
1. Somtimes I do not trust visual studio to run the ng build for me, you may build the client app through comman line.

## Reviewing Consideration
* Technically there was no business logic in this application therefore, I found writing the unit test is unnecessary
* You mentioned that the address is repeated two times and I could stop after find the second instance, however I thought make the app for any generic search purposes.
* I did not find any api to make an enquiry for a particular block, so I loop thorough the available transactions.
* It would be useful to have signalr to show the progress bar of how the search is going on. 
* I could do some validation for the entries however I should learn about the different data types to make this possible
* Also we can add some caching around the search if it is likely to be searched again (Not sure if the block transactions can change)
