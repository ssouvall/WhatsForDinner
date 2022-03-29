import React from 'react';
import ShoppingListForm from '../form/ShoppingListForm';

function ShoppingListDashboard() {
    return(
        <>
            <h3>Hi there from the dashboard</h3>
            {/* Grid here similar to the recipe dashboard. Main content is selected shopping list with an accordian menu of recipes 
            and an assembled shopping list sorted by category
            
            On the right sidebar are filters and search bar as well as a "create new shopping list button" and a dropdown menu 
            allowing the user to change shopping lists*/}
            <ShoppingListForm />
        </>
    )
}

export default ShoppingListDashboard;