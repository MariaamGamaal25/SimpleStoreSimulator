
//open System
//open System.Windows.Forms
//open System.Collections.Generic

//// Define product type
//type Product = { Name: string; Price: float; Description: string }

//// Initialize product catalog
//let products = [
//    { Name = "Laptop"; Price = 1000.0; Description = "High-performance laptop" }
//    { Name = "Phone"; Price = 500.0; Description = "Latest model smartphone" }
//    { Name = "Headphones"; Price = 100.0; Description = "Noise-cancelling headphones" }
//]

//// Cart: Dictionary to store products and their quantities
//let cart = Dictionary<Product, int>()

//// Function to calculate total cost
//let calculateTotal (cart: Dictionary<Product, int>) =
//    cart |> Seq.sumBy (fun kvp -> kvp.Key.Price * float kvp.Value)

//// Function to refresh cart display
//let refreshCartDisplay (cartList: ListBox) =
//    cartList.Items.Clear()
//    cart
//    |> Seq.iter (fun kvp -> cartList.Items.Add($"{kvp.Key.Name} - Qty: {kvp.Value} - ${kvp.Key.Price * float kvp.Value}") |> ignore)

//// GUI setup
//let form = new Form(Text = "Simple Store Simulator", Width = 600, Height = 400)

//let productList = new ListBox(Top = 20, Left = 20, Width = 250, Height = 150)
//products |> List.iter (fun p -> productList.Items.Add($"{p.Name} - ${p.Price}: {p.Description}") |> ignore)

//let cartList = new ListBox(Top = 20, Left = 300, Width = 250, Height = 150)

//let addButton = new Button(Text = "+", Top = 200, Left = 300, Width = 50)
//let removeButton = new Button(Text = "-", Top = 200, Left = 360, Width = 50)
//let checkoutButton = new Button(Text = "Checkout", Top = 240, Left = 300, Width = 120)

//// Add controls to the form
//form.Controls.AddRange [| productList; cartList; addButton; removeButton; checkoutButton |]

//// Event handlers
//addButton.Click.Add(fun _ ->
//    if productList.SelectedIndex >= 0 then
//        let selectedProduct = products.[productList.SelectedIndex]
//        if cart.ContainsKey(selectedProduct) then
//            cart.[selectedProduct] <- cart.[selectedProduct] + 1
//        else
//            cart.Add(selectedProduct, 1)
//        refreshCartDisplay(cartList)
//)

//removeButton.Click.Add(fun _ ->
//    if cartList.SelectedIndex >= 0 then
//        let selectedProduct =
//            cart
//            |> Seq.item cartList.SelectedIndex // Get the KeyValuePair<Product, int>
//            |> fun kvp -> kvp.Key             // Access the Key property to get the product
//        if cart.ContainsKey(selectedProduct) then
//            if cart.[selectedProduct] > 1 then
//                cart.[selectedProduct] <- cart.[selectedProduct] - 1
//            else
//                cart.Remove(selectedProduct) |> ignore
//        refreshCartDisplay(cartList)
//)

//checkoutButton.Click.Add(fun _ ->
//    let total = calculateTotal cart
//    MessageBox.Show($"Total cost: ${total}", "Checkout", MessageBoxButtons.OK) |> ignore
//)

//// Run the application
//[<EntryPoint>]
//let main _ =
//    Application.Run(form)
//    0


//---------------------------------------------------------------------------------------


//open System
//open System.Windows.Forms
//open System.Collections.Generic

//// Define product type
//type Product = { Name: string; Price: float; Description: string }

//// Initialize product catalog
//let products = [
//    { Name = "Laptop"; Price = 1000.0; Description = "High-performance laptop" }
//    { Name = "Phone"; Price = 500.0; Description = "Latest model smartphone" }
//    { Name = "Headphones"; Price = 100.0; Description = "Noise-cancelling headphones" }
//    { Name = "Smartwatch"; Price = 150.0; Description = "Wearable fitness tracker" }
//    { Name = "Tablet"; Price = 300.0; Description = "Portable tablet with high resolution" }
//]

//// Cart: Dictionary to store products and their quantities
//let cart = Dictionary<Product, int>()

//// Function to calculate the total price of the cart
//let calculateTotal (cart: Dictionary<Product, int>) =
//    cart |> Seq.sumBy (fun kvp -> kvp.Key.Price * float kvp.Value)

//// Function to refresh cart display
//let refreshCartWithButtons (cartList: ListBox) (cart: Dictionary<Product, int>) =
//    // Clear the existing items
//    cartList.Items.Clear()

//    // Add the current items in the cart
//    cart
//    |> Seq.iter (fun kvp ->
//        let product = kvp.Key
//        let quantity = kvp.Value
//        // Create item text
//        let itemText = $"{product.Name} - Qty: {quantity} - ${product.Price * float quantity}"
//        // Add the item to the list box
//        cartList.Items.Add(itemText) |> ignore
//    )

//// GUI setup
//let form = new Form(Text = "Simple Store Simulator", Width = 800, Height = 400)
//form.BackColor <- System.Drawing.Color.LightGray
//form.Opacity <- 0.0 // Set initial opacity to 0 (invisible)

//// Add Timer for animation (fade-in effect)
//let fadeTimer = new Timer(Interval = 50)
//fadeTimer.Start()

//// Timer event handler to increase opacity gradually
//fadeTimer.Tick.Add(fun _ ->
//    if form.Opacity < 1.0 then
//        form.Opacity <- form.Opacity + 0.05
//    else
//        fadeTimer.Stop() // Stop the timer once opacity reaches 1
//)

//// Product ListBox
//let productList = new ListBox(Top = 20, Left = 20, Width = 300, Height = 150)
//products |> List.iter (fun p -> productList.Items.Add($"{p.Name} - ${p.Price}: {p.Description}") |> ignore)
//productList.BackColor <- System.Drawing.Color.White
//productList.BorderStyle <- BorderStyle.FixedSingle

//// Cart list box
//let cartList = new ListBox(Top = 20, Left = 350, Width = 300, Height = 150)
//cartList.BackColor <- System.Drawing.Color.White
//cartList.BorderStyle <- BorderStyle.FixedSingle

//// Colorful Buttons for the main window
//let addButton = new Button(Text = "Add to Cart", Top = 200, Left = 300, Width = 100)
//addButton.BackColor <- System.Drawing.Color.Green
//addButton.ForeColor <- System.Drawing.Color.White
//addButton.FlatStyle <- FlatStyle.Flat
//addButton.FlatAppearance.BorderSize <- 0

//let openCartButton = new Button(Text = "Open Cart", Top = 240, Left = 300, Width = 100)
//openCartButton.BackColor <- System.Drawing.Color.Cyan
//openCartButton.ForeColor <- System.Drawing.Color.White
//openCartButton.FlatStyle <- FlatStyle.Flat
//openCartButton.FlatAppearance.BorderSize <- 0

//// Event handlers for main window buttons
//addButton.Click.Add(fun _ ->
//    if productList.SelectedIndex >= 0 then
//        let selectedProduct = products.[productList.SelectedIndex]
//        if cart.ContainsKey(selectedProduct) then
//            cart.[selectedProduct] <- cart.[selectedProduct] + 1
//        else
//            cart.Add(selectedProduct, 1)
//        refreshCartWithButtons cartList cart
//)

//openCartButton.Click.Add(fun _ ->
//    // Open a new form to show the cart
//    let cartForm = new Form(Text = "Your Cart", Width = 600, Height = 400)
//    let cartListWithButtons = new ListBox(Top = 20, Left = 20, Width = 500, Height = 250)
//    refreshCartWithButtons cartListWithButtons cart
    
//    // Create the "Add" and "Remove" buttons for the cart
//    let addQtyButton = new Button(Text = "Add +", Top = 280, Left = 150, Width = 75)
//    addQtyButton.BackColor <- System.Drawing.Color.Orange
//    addQtyButton.ForeColor <- System.Drawing.Color.White
//    addQtyButton.FlatStyle <- FlatStyle.Flat
//    addQtyButton.FlatAppearance.BorderSize <- 0

//    let removeQtyButton = new Button(Text = "Remove -", Top = 280, Left = 230, Width = 75)
//    removeQtyButton.BackColor <- System.Drawing.Color.OrangeRed
//    removeQtyButton.ForeColor <- System.Drawing.Color.White
//    removeQtyButton.FlatStyle <- FlatStyle.Flat
//    removeQtyButton.FlatAppearance.BorderSize <- 0

//    // Checkout button
//    let checkoutButton = new Button(Text = "Checkout", Top = 320, Left = 150, Width = 100)
//    checkoutButton.BackColor <- System.Drawing.Color.Purple
//    checkoutButton.ForeColor <- System.Drawing.Color.White
//    checkoutButton.FlatStyle <- FlatStyle.Flat
//    checkoutButton.FlatAppearance.BorderSize <- 0

//    // Event handler for adding quantity in cart
//    addQtyButton.Click.Add(fun _ ->
//        if cartListWithButtons.SelectedIndex >= 0 then
//            let selectedItem = cartListWithButtons.SelectedItem.ToString()
//            let productName = selectedItem.Split('-').[0].Trim() // Get product name
//            let selectedProduct = products |> List.find (fun p -> p.Name = productName)
//            cart.[selectedProduct] <- cart.[selectedProduct] + 1
//            refreshCartWithButtons cartListWithButtons cart
//    )

//    // Event handler for removing quantity in cart
//    removeQtyButton.Click.Add(fun _ ->
//        if cartListWithButtons.SelectedIndex >= 0 then
//            let selectedItem = cartListWithButtons.SelectedItem.ToString()
//            let productName = selectedItem.Split('-').[0].Trim() // Get product name
//            let selectedProduct = products |> List.find (fun p -> p.Name = productName)
//            if cart.ContainsKey(selectedProduct) then
//                if cart.[selectedProduct] > 1 then
//                    cart.[selectedProduct] <- cart.[selectedProduct] - 1
//                else
//                    cart.Remove(selectedProduct) |> ignore
//                refreshCartWithButtons cartListWithButtons cart
//    )

//    // Event handler for checkout
//    checkoutButton.Click.Add(fun _ ->
//        let total = calculateTotal cart
//        MessageBox.Show($"Total cost: ${total}", "Checkout", MessageBoxButtons.OK) |> ignore
//    )

//    // Add the buttons to the cart form
//    cartForm.Controls.AddRange [| cartListWithButtons; addQtyButton; removeQtyButton; checkoutButton |]
//    cartForm.ShowDialog() |> ignore // Handle the dialog result properly
//)

//// Removing Hover Effect from main window buttons
//// Main window buttons don't change color on hover now

//// Add controls to the form (main window)
//form.Controls.AddRange [| productList; cartList; addButton; openCartButton |]

//// Run the application
//[<EntryPoint>]
//let main _ =
//    Application.Run(form)
//    0


//open System
//open System.Windows.Forms
//open System.Collections.Generic

//// Define product type
//type Product = { Name: string; Price: float; Description: string }

//// Initialize product catalog
//let products = [
//    { Name = "Laptop"; Price = 1000.0; Description = "High-performance laptop" }
//    { Name = "Phone"; Price = 500.0; Description = "Latest model smartphone" }
//    { Name = "Headphones"; Price = 100.0; Description = "Noise-cancelling headphones" }
//    { Name = "Smartwatch"; Price = 150.0; Description = "Wearable fitness tracker" }
//    { Name = "Tablet"; Price = 300.0; Description = "Portable tablet with high resolution" }
//]

//// Cart: Dictionary to store products and their quantities
//let cart = Dictionary<Product, int>()

//// Function to calculate the total price of the cart
//let calculateTotal (cart: Dictionary<Product, int>) =
//    cart |> Seq.sumBy (fun kvp -> kvp.Key.Price * float kvp.Value)

//// Function to refresh cart display
//let refreshCartWithButtons (cartList: ListBox) (cart: Dictionary<Product, int>) =
//    // Clear the existing items
//    cartList.Items.Clear()

//    // Add the current items in the cart
//    cart
//    |> Seq.iter (fun kvp ->
//        let product = kvp.Key
//        let quantity = kvp.Value
//        // Create item text
//        let itemText = $"{product.Name} - Qty: {quantity} - ${product.Price * float quantity}"
//        // Add the item to the list box
//        cartList.Items.Add(itemText) |> ignore
//    )

//// GUI setup
//let form = new Form(Text = "Simple Store Simulator", Width = 800, Height = 400)
//form.BackColor <- System.Drawing.Color.LightGray
//form.Opacity <- 0.0 // Set initial opacity to 0 (invisible)

//// Add Timer for animation (fade-in effect)
//let fadeTimer = new Timer(Interval = 50)
//fadeTimer.Start()

//// Timer event handler to increase opacity gradually
//fadeTimer.Tick.Add(fun _ ->
//    if form.Opacity < 1.0 then
//        form.Opacity <- form.Opacity + 0.05
//    else
//        fadeTimer.Stop() // Stop the timer once opacity reaches 1
//)

//// Product ListBox
//let productList = new ListBox(Top = 20, Left = 20, Width = 300, Height = 150)
//products |> List.iter (fun p -> productList.Items.Add($"{p.Name} - ${p.Price}: {p.Description}") |> ignore)
//productList.BackColor <- System.Drawing.Color.White
//productList.BorderStyle <- BorderStyle.FixedSingle

//// Cart list box
//let cartList = new ListBox(Top = 20, Left = 350, Width = 300, Height = 150)
//cartList.BackColor <- System.Drawing.Color.White
//cartList.BorderStyle <- BorderStyle.FixedSingle

//// Colorful Buttons for the main window
//let addButton = new Button(Text = "Add to Cart", Top = 200, Left = 300, Width = 100)
//addButton.BackColor <- System.Drawing.Color.Green
//addButton.ForeColor <- System.Drawing.Color.White
//addButton.FlatStyle <- FlatStyle.Flat
//addButton.FlatAppearance.BorderSize <- 0

//let openCartButton = new Button(Text = "Open Cart", Top = 240, Left = 300, Width = 100)
//openCartButton.BackColor <- System.Drawing.Color.Cyan
//openCartButton.ForeColor <- System.Drawing.Color.White
//openCartButton.FlatStyle <- FlatStyle.Flat
//openCartButton.FlatAppearance.BorderSize <- 0

//// Event handlers for main window buttons
//addButton.Click.Add(fun _ ->
//    if productList.SelectedIndex >= 0 then
//        let selectedProduct = products.[productList.SelectedIndex]
//        if cart.ContainsKey(selectedProduct) then
//            cart.[selectedProduct] <- cart.[selectedProduct] + 1
//        else
//            cart.Add(selectedProduct, 1)
//        refreshCartWithButtons cartList cart
//)

//openCartButton.Click.Add(fun _ ->
//    // Open a new form to show the cart
//    let cartForm = new Form(Text = "Your Cart", Width = 600, Height = 400)
//    let cartListWithButtons = new ListBox(Top = 20, Left = 20, Width = 500, Height = 250)
//    refreshCartWithButtons cartListWithButtons cart
    
//    // Create the "Add" and "Remove" buttons for the cart
//    let addQtyButton = new Button(Text = "Add +", Top = 280, Left = 150, Width = 75)
//    addQtyButton.BackColor <- System.Drawing.Color.Orange
//    addQtyButton.ForeColor <- System.Drawing.Color.White
//    addQtyButton.FlatStyle <- FlatStyle.Flat
//    addQtyButton.FlatAppearance.BorderSize <- 0

//    let removeQtyButton = new Button(Text = "Remove -", Top = 280, Left = 230, Width = 75)
//    removeQtyButton.BackColor <- System.Drawing.Color.OrangeRed
//    removeQtyButton.ForeColor <- System.Drawing.Color.White
//    removeQtyButton.FlatStyle <- FlatStyle.Flat
//    removeQtyButton.FlatAppearance.BorderSize <- 0

//    // Checkout button
//    let checkoutButton = new Button(Text = "Checkout", Top = 320, Left = 150, Width = 100)
//    checkoutButton.BackColor <- System.Drawing.Color.Purple
//    checkoutButton.ForeColor <- System.Drawing.Color.White
//    checkoutButton.FlatStyle <- FlatStyle.Flat
//    checkoutButton.FlatAppearance.BorderSize <- 0

//    // Event handler for adding quantity in cart
//    addQtyButton.Click.Add(fun _ ->
//        if cartListWithButtons.SelectedIndex >= 0 then
//            let selectedItem = cartListWithButtons.SelectedItem.ToString()
//            let productName = selectedItem.Split('-').[0].Trim() // Get product name
//            let selectedProduct = products |> List.find (fun p -> p.Name = productName)
//            cart.[selectedProduct] <- cart.[selectedProduct] + 1
//            refreshCartWithButtons cartListWithButtons cart
//    )

//    // Event handler for removing quantity in cart
//    removeQtyButton.Click.Add(fun _ ->
//        if cartListWithButtons.SelectedIndex >= 0 then
//            let selectedItem = cartListWithButtons.SelectedItem.ToString()
//            let productName = selectedItem.Split('-').[0].Trim() // Get product name
//            let selectedProduct = products |> List.find (fun p -> p.Name = productName)
//            if cart.ContainsKey(selectedProduct) then
//                if cart.[selectedProduct] > 1 then
//                    cart.[selectedProduct] <- cart.[selectedProduct] - 1
//                else
//                    cart.Remove(selectedProduct) |> ignore
//                refreshCartWithButtons cartListWithButtons cart
//    )

//    // Event handler for checkout
//    checkoutButton.Click.Add(fun _ ->
//        let total = calculateTotal cart
//        MessageBox.Show($"Total cost: ${total}", "Checkout", MessageBoxButtons.OK) |> ignore
//    )

//    // Create "Add New Product" button
//    let addNewProductButton = new Button(Text = "Add New Product", Top = 360, Left = 150, Width = 120)
//    addNewProductButton.BackColor <- System.Drawing.Color.LightBlue
//    addNewProductButton.ForeColor <- System.Drawing.Color.White
//    addNewProductButton.FlatStyle <- FlatStyle.Flat
//    addNewProductButton.FlatAppearance.BorderSize <- 0

//    // Event handler for "Add New Product" button
//    addNewProductButton.Click.Add(fun _ ->
//        // Hide cart form and show main window again
//        cartForm.Hide()
//        form.Show()
//    )

//    // Add the buttons to the cart form
//    cartForm.Controls.AddRange [| cartListWithButtons; addQtyButton; removeQtyButton; checkoutButton; addNewProductButton |]
    
//    // Hide main form, show cart form
//    form.Hide()
//    cartForm.ShowDialog() |> ignore // Handle the dialog result properly
//)

//// Removing Hover Effect from main window buttons
//// Main window buttons don't change color on hover now

//// Add controls to the form (main window)
//form.Controls.AddRange [| productList; cartList; addButton; openCartButton |]

//// Run the application
//[<EntryPoint>]
//let main _ =
//    Application.Run(form)
//    0

//-------------------------------------------------------------
   
open System
open System.Windows.Forms
open System.Collections.Generic
open System.Drawing //L

// Define product type
type Product = { Name: string; Price: float; Description: string }

// Initialize product catalog
let products = [
    { Name = "Laptop"; Price = 1000.0; Description = "High-performance laptop" }
    { Name = "Phone"; Price = 500.0; Description = "Latest model smartphone" }
    { Name = "Headphones"; Price = 100.0; Description = "Noise-cancelling headphones" }
    { Name = "Smartwatch"; Price = 150.0; Description = "Wearable fitness tracker" }
    { Name = "Tablet"; Price = 300.0; Description = "Portable tablet with high resolution" }
]

// Cart: Dictionary to store products and their quantities
let cart = Dictionary<Product, int>()

// Function to calculate the total price of the cart
let calculateTotal (cart: Dictionary<Product, int>) =
    cart |> Seq.sumBy (fun kvp -> kvp.Key.Price * float kvp.Value)

// Function to refresh cart display
let refreshCartWithButtons (cartList: ListBox) (cart: Dictionary<Product, int>) =
    // Clear the existing items
    cartList.Items.Clear()

    // Add the current items in the cart
    cart
    |> Seq.iter (fun kvp ->
        let product = kvp.Key
        let quantity = kvp.Value
        // Create item text
        let itemText = $"{product.Name} - Qty: {quantity} - ${product.Price * float quantity}"
        // Add the item to the list box
        cartList.Items.Add(itemText) |> ignore
    )

// GUI setup
let form = new Form(Text = "Simple Store Simulator", Width = 800, Height = 400)
form.BackColor <- System.Drawing.Color.LightGray
form.Opacity <- 0.0 // Set initial opacity to 0 (invisible)

// Add Timer for animation (fade-in effect)
let fadeTimer = new Timer(Interval = 50)
fadeTimer.Start()

// Timer event handler to increase opacity gradually
fadeTimer.Tick.Add(fun _ ->
    if form.Opacity < 1.0 then
        form.Opacity <- form.Opacity + 0.05
    else
        fadeTimer.Stop() // Stop the timer once opacity reaches 1
)

// Product ListBox
let productList = new ListBox(Top = 20, Left = 20, Width = 300, Height = 150)
products |> List.iter (fun p -> productList.Items.Add($"{p.Name} - ${p.Price}: {p.Description}") |> ignore)
productList.BackColor <- System.Drawing.Color.White
productList.BorderStyle <- BorderStyle.FixedSingle

// Cart list box
let cartList = new ListBox(Top = 20, Left = 350, Width = 300, Height = 150)
cartList.BackColor <- System.Drawing.Color.White
cartList.BorderStyle <- BorderStyle.FixedSingle

// Colorful Buttons for the main window
let addButton = new Button(Text = "Add to Cart", Top = 200, Left = 300, Width = 100)
addButton.BackColor <- System.Drawing.Color.Green
addButton.ForeColor <- System.Drawing.Color.White
addButton.FlatStyle <- FlatStyle.Flat
addButton.FlatAppearance.BorderSize <- 0

let openCartButton = new Button(Text = "Open Cart", Top = 240, Left = 300, Width = 100)
openCartButton.BackColor <- System.Drawing.Color.Cyan
openCartButton.ForeColor <- System.Drawing.Color.White
openCartButton.FlatStyle <- FlatStyle.Flat
openCartButton.FlatAppearance.BorderSize <- 0

// Event handlers for main window buttons
addButton.Click.Add(fun _ ->
    if productList.SelectedIndex >= 0 then
        let selectedProduct = products.[productList.SelectedIndex]
        if cart.ContainsKey(selectedProduct) then
            cart.[selectedProduct] <- cart.[selectedProduct] + 1
        else
            cart.Add(selectedProduct, 1)
        refreshCartWithButtons cartList cart
)

openCartButton.Click.Add(fun _ ->
    // Open a new form to show the cart
    let cartForm = new Form(Text = "Your Cart", Width = 600, Height = 400)
    let cartListWithButtons = new ListBox(Top = 20, Left = 20, Width = 500, Height = 250)
    refreshCartWithButtons cartListWithButtons cart
    
    // Create the "Add" and "Remove" buttons for the cart
    let addQtyButton = new Button(Text = "Add +", Top = 280, Left = 150, Width = 75)
    addQtyButton.BackColor <- System.Drawing.Color.Orange
    addQtyButton.ForeColor <- System.Drawing.Color.White
    addQtyButton.FlatStyle <- FlatStyle.Flat
    addQtyButton.FlatAppearance.BorderSize <- 0

    let removeQtyButton = new Button(Text = "Remove -", Top = 280, Left = 230, Width = 75)
    removeQtyButton.BackColor <- System.Drawing.Color.OrangeRed
    removeQtyButton.ForeColor <- System.Drawing.Color.White
    removeQtyButton.FlatStyle <- FlatStyle.Flat
    removeQtyButton.FlatAppearance.BorderSize <- 0

    // Add product button
    let addProductButton = new Button(Text = "Add Product", Top = 320, Left = 310, Width = 100)
    addProductButton.BackColor <- System.Drawing.Color.Blue
    addProductButton.ForeColor <- System.Drawing.Color.White
    addProductButton.FlatStyle <- FlatStyle.Flat
    addProductButton.FlatAppearance.BorderSize <- 0

    // Checkout button
    let checkoutButton = new Button(Text = "Checkout", Top = 320, Left = 150, Width = 100)
    checkoutButton.BackColor <- System.Drawing.Color.Purple
    checkoutButton.ForeColor <- System.Drawing.Color.White
    checkoutButton.FlatStyle <- FlatStyle.Flat
    checkoutButton.FlatAppearance.BorderSize <- 0

    // Event handler for adding quantity in cart
    addQtyButton.Click.Add(fun _ ->
        if cartListWithButtons.SelectedIndex >= 0 then
            let selectedItem = cartListWithButtons.SelectedItem.ToString()
            let productName = selectedItem.Split('-').[0].Trim() // Get product name
            let selectedProduct = products |> List.find (fun p -> p.Name = productName)
            cart.[selectedProduct] <- cart.[selectedProduct] + 1
            refreshCartWithButtons cartListWithButtons cart
    )

    // Event handler for removing quantity in cart
    removeQtyButton.Click.Add(fun _ ->
        if cartListWithButtons.SelectedIndex >= 0 then
            let selectedItem = cartListWithButtons.SelectedItem.ToString()
            let productName = selectedItem.Split('-').[0].Trim() // Get product name
            let selectedProduct = products |> List.find (fun p -> p.Name = productName)
            if cart.ContainsKey(selectedProduct) then
                if cart.[selectedProduct] > 1 then
                    cart.[selectedProduct] <- cart.[selectedProduct] - 1
                else
                    cart.Remove(selectedProduct) |> ignore
                refreshCartWithButtons cartListWithButtons cart
    )

    // Event handler for adding new products
    addProductButton.Click.Add(fun _ ->
        // Create the product selection form
        let productSelectionForm = new Form(Text = "Select Product to Add", Width = 400, Height = 300)

        // Product selection list box
        let productSelectionList = new ListBox(Top = 20, Left = 20, Width = 340, Height = 200)
        products |> List.iter (fun p -> 
            productSelectionList.Items.Add($"{p.Name} - ${p.Price}: {p.Description}") |> ignore
        )

        // Add button in the product selection form
        let addSelectedButton = new Button(Text = "Add", Top = 240, Left = 150, Width = 100)
        addSelectedButton.Click.Add(fun _ ->
            if productSelectionList.SelectedIndex >= 0 then
                // Retrieve the selected product
                let selectedProduct = products.[productSelectionList.SelectedIndex]

                // Add the product to the cart
                if cart.ContainsKey(selectedProduct) then
                    cart.[selectedProduct] <- cart.[selectedProduct] + 1
                else
                    cart.Add(selectedProduct, 1)

                // Refresh the cart list in the parent form
                refreshCartWithButtons cartListWithButtons cart

                // Close the product selection form
                productSelectionForm.Close()
        )

        // Add controls to the product selection form
        productSelectionForm.Controls.AddRange [| productSelectionList; addSelectedButton |]

        // Show the product selection form
        productSelectionForm.ShowDialog() |> ignore
    )

    // Event handler for checkout
    checkoutButton.Click.Add(fun _ ->
        let total = calculateTotal cart
        MessageBox.Show($"Total cost: ${total}", "Checkout", MessageBoxButtons.OK) |> ignore
    )

    // Add the buttons to the cart form
    cartForm.Controls.AddRange [| cartListWithButtons; addQtyButton; removeQtyButton; checkoutButton; addProductButton |]
    cartForm.ShowDialog() |> ignore // Handle the dialog result properly
)

// Add controls to the form (main window)
form.Controls.AddRange [| productList; cartList; addButton; openCartButton |]






// Load the background image
let backgroundImage = Image.FromFile("D:\cartimg.jpeg")
form.BackgroundImage <- backgroundImage
    
    // Set the layout of the background image
form.BackgroundImageLayout <- ImageLayout.Stretch

// Run the application
[<EntryPoint>]
let main _ =
    Application.Run(form)
    0

