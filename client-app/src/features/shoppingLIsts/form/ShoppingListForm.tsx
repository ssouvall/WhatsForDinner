import React, { useEffect, useState } from 'react';
import { Dropdown, Form, Segment } from 'semantic-ui-react';
import agent from '../../../app/api/agent';
import { DropDownDataItem } from '../../../app/models/dropDownDataItem';
import { IngredientListItem } from '../../../app/models/ingredientListItem';
import { Recipe } from '../../../app/models/recipe';
import { ShoppingList } from '../../../app/models/shoppingList';

function ShoppingListForm() {
    useEffect(() => {
        if(selectedIngredient !== undefined) setSelectedIngredient(selectedIngredient);
        if(selectedRecipe !== undefined) setSelectedRecipe(selectedRecipe);
        agent.Recipes.list().then(data => {
            if(data.length !== 0){
                 data.forEach(d => {
                    var dataObj = {
                        key: d.id,
                        value: d.name,
                        text: d.name
                    }
                    if (!allRecipes.find(i => i.key === dataObj.key)){
                        allRecipes.push(dataObj);
                    }
                })
                setAllRecipes(allRecipes);
            }
        })
    }, [])

    const [shoppingList, setShoppingList] = useState<ShoppingList>({
        id: '',
        name: '',
        recipes: [],
        ingredients: []
    })
    const [selectedIngredient, setSelectedIngredient] = useState<IngredientListItem>({
        id: '',
        name: '',
        ingredientId: '',
        notes: '',
        quantity: 0,
        quantityUnit: '',
        recipeId: '',
        isComplete: false
    })
    const [selectedRecipe, setSelectedRecipe] = useState<Recipe>({
        id: '',
        name: '',
        category: '',
        description: '',
        instructions: '',
        ingredientListItems: []
    })
    const [allRecipes, setAllRecipes] = useState<DropDownDataItem<Recipe>[]>([]);
    const [selectedRecipes, setSelectedRecipes] = useState<DropDownDataItem<Recipe>[]>([])
    const [ingredientItems, setIngredientItems] = useState<DropDownDataItem<IngredientListItem>[]>([])

    function handleSubmit(){

    }

    function handleInputChange(){

    }

    function handleDropDownChange(){
        
    }

    return (
        <Segment>
            <Form onSubmit={handleSubmit} autoComplete='off' >
                <Form.Input placeholder="Shopping List Name" value={shoppingList.name} name='name' onChange={handleInputChange} />
                <Dropdown 
                    placeholder="Add Recipes to this List..." 
                    name="recipes"
                    value={selectedRecipe.name}
                    fluid
                    search
                    selection
                    options={allRecipes}
                    onChange={handleDropDownChange} 
                />
            </Form>
        </Segment>
    )
}

export default ShoppingListForm;