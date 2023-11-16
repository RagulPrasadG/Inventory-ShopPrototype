# MAT-I
This is a test project for the Module Assesment Test(MAT-I) in outscal advanced game development program the focus of this assessment is to create a inventory and shop system prototype.
* The Game Screen will be divided into 2 different UI Panels as shown below, each with a Grid UI:
![Base Screen](https://github.com/RagulPrasadG/MAT-I/assets/61055516/ad21d5a1-7390-4ea1-a559-d97401cb7b0b)
* One Panel represents Shop and the other represents Player Inventory
* Your current Currency will displayed on the top corner of the Screen
* Initially, your player inventory will be empty and you will have no money
* There will be many items in the shop that you can buy.
  
* Each item in the shop or inventory will have the following properties:
 * Type
 * Icon
 * Item description
 * Buying Price
 * Selling Price
 * Weight
 * Rarity
 * Quantity

<h1>ItemTypes</h1>
  
Items can be of the following types:
* Materials
* Weapons
* Consumables
* Treasure
The shop UI will have 4 tabs for each item type
Selecting a tab will display available items of that type in the shop.


<h1>Selling & Buying Price</h1>

When an item is in the shop, selecting that item should show it’s buying price
When an item is in the inventory, selecting that should show it’s selling price


<h1>Weight</h1>

There would be a maximum weight the Player can carry in their inventory.
Each item will have a certain weight.
When an item is bought or sold the player’s inventory weight will be updated accordingly.
The cumulative weight of all the items in the player inventory should always be less than the Maximum Weight.


<h1>Rarity</h1>

Each item can be of any of the below Rarity Levels:
* Very Common
* Common
* Rare
* Epic
* Legendary
The Value of the item will accordingly be more or less.


<h1>Icon & Description</h1>

Each item will have a unique Icon and Text Description
Any of the Items in inventory or the shop when selected, its icon, description, value, weight, and any other details will be shown in UI like in the below reference image:

The layout of your game screen can be designed and tweaked according to your preferences as long as all the features are implemented correctly.


<h1>Gathering Resources</h1>

At the bottom, there should be a button to gather resources.
Initially, the player will have nothing in the inventory and no money as well.
The player can click the gather resource button and collect some random items.
The rarity of items gathered will be directly proportional to the cumulative value of the player’s inventory.
If the inventory’s weight offshoots the maximum weight that can be carried, the gathering resources button will not work and a popup will be shown to indicate the same to the player.


<h1>Buying & Selling Items</h1>

Each Item in the shop when selected will show a Buy Button while showing its details.
If you have enough money you can buy that item and it will shift in your inventory.
If you don’t have enough money, a popup should be displayed to indicate the same.
If you select an item in your inventory there should be a sell button along with the details of that item being shown.
Clicking it should remove that item from the inventory and move it back to the shop.
Upon selecting “Buy Item” and “Sell Item” button, a popup will be shown to the player where they can select the quantity they want to buy or sell.
Player can increase or decrease the quantity of the item using ‘+’ and ‘-’ buttons displayed in the popup.
After selecting the quantity of the item, there should be a popup asking for conformation.


<h1>When buying an item from the shop: (If conditions are satisfied)</h1>

A sound will be played
Resources will be deducted
An overlay text will appear for a few seconds and then disappear for example: “You bought wxyz”
The bought item will be placed in your inventory UI
Current weight of the inventory will be increased accordingly.

<h1>When Selling an item</h1>

A sound will be played
Resources will be increased
Inventory UI will be updated
An overlay text will appear for a few seconds and then disappear for example: “You gained **** gold”
The current Cumulative weight of the inventory will be decreased
  
<h1>Design Pattern & Principles used</h1>
* Observer pattern
* MVC(Model View Controller)
* Dependency Injection
  
Check out the gameplay
video here👇
