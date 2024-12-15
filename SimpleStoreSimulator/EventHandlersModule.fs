module EventHandlersModule

open System.Windows.Forms
open ProductModule
open CartModule
open GuiModule

// Function to add event handlers
let addEventHandlers (fadeTimer: Timer) (form: Form) (addButton: Button) (openCartButton: Button) (cartList: ListBox) (products: Product list) =
    // Add event handler for fade effect
    fadeTimer.Tick.Add(fun _ ->
        if form.Opacity < 1.0 then
            form.Opacity <- form.Opacity + 0.05
        else
            fadeTimer.Stop()
    )

    // Add event handler for add button
    addButton.Click.Add(fun _ -> 
        if productList.SelectedIndex >= 0 then
            let selectedProduct = products.[productList.SelectedIndex]
            if cart.ContainsKey(selectedProduct) then
                cart.[selectedProduct] <- cart.[selectedProduct] + 1
            else
                cart.Add(selectedProduct, 1)
            refreshCartWithButtons cartList cart
    )


    // Add event handler for open cart button
    openCartButton.Click.Add(fun _ -> 
        let cartForm = new Form(Text = "Your Cart", Width = 600, Height = 400)
        let cartListWithButtons = new ListBox(Top = 20, Left = 20, Width = 500, Height = 250)
        refreshCartWithButtons cartListWithButtons cart

        // Create buttons for cart actions
        let addQtyButton = new Button(Text = " Add + ", Top = 280, Left = 150, Width = 100)
        
        addQtyButton.BackColor <- System.Drawing.Color.DeepPink
        addQtyButton.ForeColor <- System.Drawing.Color.White
        addQtyButton.FlatStyle <- FlatStyle.Popup
        addQtyButton.FlatAppearance.BorderSize <- 0
        addQtyButton.Font <- new System.Drawing.Font("Arial", 12.0F, System.Drawing.FontStyle.Regular)


        let removeQtyButton = new Button(Text = "Remove -", Top = 280, Left = 300, Width = 100)
        removeQtyButton.BackColor <- System.Drawing.Color.DeepPink
        removeQtyButton.ForeColor <- System.Drawing.Color.White
        removeQtyButton.FlatStyle <- FlatStyle.Popup
        removeQtyButton.FlatAppearance.BorderSize <- 0
        removeQtyButton.Font <- new System.Drawing.Font("Arial", 12.0F, System.Drawing.FontStyle.Regular)


        let checkoutButton = new Button(Text = "Checkout", Top = 320, Left = 150, Width = 100)
        checkoutButton.BackColor <- System.Drawing.Color.DeepPink
        checkoutButton.ForeColor <- System.Drawing.Color.White
        checkoutButton.FlatStyle <- FlatStyle.Popup
        checkoutButton.FlatAppearance.BorderSize <- 0
        checkoutButton.Font <- new System.Drawing.Font("Arial", 12.0F, System.Drawing.FontStyle.Regular)





        // Add event handlers for buttons
        addQtyButton.Click.Add(fun _ ->
            if cartListWithButtons.SelectedIndex >= 0 then
                let selectedItem = cartListWithButtons.SelectedItem.ToString()
                let productName = selectedItem.Split('-').[0].Trim()
                let selectedProduct = products |> List.find (fun p -> p.Name = productName)
                cart.[selectedProduct] <- cart.[selectedProduct] + 1
                refreshCartWithButtons cartListWithButtons cart
        )
        removeQtyButton.Click.Add(fun _ ->
            if cartListWithButtons.SelectedIndex >= 0 then
                let selectedItem = cartListWithButtons.SelectedItem.ToString()
                let productName = selectedItem.Split('-').[0].Trim()
                let selectedProduct = products |> List.find (fun p -> p.Name = productName)
                if cart.ContainsKey(selectedProduct) then
                    if cart.[selectedProduct] > 1 then
                        cart.[selectedProduct] <- cart.[selectedProduct] - 1
                    else
                        cart.Remove(selectedProduct) |> ignore
                    refreshCartWithButtons cartListWithButtons cart
        )
        checkoutButton.Click.Add(fun _ ->
            let total = calculateTotal cart
            MessageBox.Show($"Total cost: ${total}", "Checkout", MessageBoxButtons.OK) |> ignore
        )

        // Add the "Add Product" button only in the cart window
        let addProductButton = new Button(Text = "Add Product", Top = 320, Left = 300, Width = 105)
        addProductButton.BackColor <- System.Drawing.Color.DeepPink
        addProductButton.ForeColor <- System.Drawing.Color.White
        addProductButton.FlatStyle <- FlatStyle.Popup
        addProductButton.FlatAppearance.BorderSize <- 0
        addProductButton.Font <- new System.Drawing.Font("Arial", 12.0F, System.Drawing.FontStyle.Regular)


        // Add event handler for "Add Product" button
        addProductButton.Click.Add(fun _ ->
            // Create the product selection form
            let productSelectionForm = new Form(Text = "Select Product to Add", Width = 400, Height = 300)

            // Product selection list box
            let productSelectionList = new ListBox(Top = 20, Left = 20, Width = 340, Height = 200)
            products |> List.iter (fun p -> 
                productSelectionList.Items.Add($"{p.Name} - ${p.Price}: {p.Description}") |> ignore
            )

            // Add button in the product selection form
            let addSelectedButton = new Button(Text = "Add", Top = 230, Left = 150, Width = 100)
            addSelectedButton.BackColor <- System.Drawing.Color.DeepPink
            addSelectedButton.ForeColor <- System.Drawing.Color.White
            addSelectedButton.FlatStyle <- FlatStyle.Popup
            addSelectedButton.FlatAppearance.BorderSize <- 0
            addSelectedButton.Font <- new System.Drawing.Font("Arial", 12.0F)
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

        // Add all buttons and controls to the cart form
        cartForm.Controls.AddRange [| cartListWithButtons; addQtyButton; removeQtyButton; checkoutButton; addProductButton |]
        
        // Show the cart form
        cartForm.ShowDialog() |> ignore
    )


