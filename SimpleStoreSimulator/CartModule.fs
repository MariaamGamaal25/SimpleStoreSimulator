module CartModule

open System.Windows.Forms   // Make sure to open this to access ListBox and other controls
open ProductModule
open System.Collections.Generic

// Create a cart to store products and quantities
let cart = Dictionary<Product, int>()

// Calculate the total price of items in the cart
let calculateTotal (cart: Dictionary<Product, int>) =
    cart |> Seq.sumBy (fun kvp -> kvp.Key.Price * float kvp.Value)

// Function to refresh cart display
let refreshCartWithButtons (cartList: ListBox) (cart: Dictionary<Product, int>) =
    cartList.Items.Clear()
    cart
    |> Seq.iter (fun kvp ->
        let product = kvp.Key
        let quantity = kvp.Value
        let itemText = $"{product.Name} - Qty: {quantity} - ${product.Price * float quantity}"
        cartList.Items.Add(itemText) |> ignore
    )



