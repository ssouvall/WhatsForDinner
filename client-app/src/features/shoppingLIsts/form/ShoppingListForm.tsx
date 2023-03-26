import React, { SyntheticEvent, useEffect, useState } from 'react';
import { Button, Dropdown, DropdownProps, Form, Segment } from 'semantic-ui-react';
import agent from '../../../app/api/agent';
import { DropDownDataItem } from '../../../app/models/dropDownDataItem';
import { IngredientListItem } from '../../../app/models/ingredientListItem';
import { Recipe } from '../../../app/models/recipe';
import { ShoppingList } from '../../../app/models/shoppingList';
import { useDispatch, useSelector } from 'react-redux';
import { addRecipesToList, setSelectedShoppingList } from "../../../redux/actions/shoppingList/shoppingListActions";
import { RootState } from '../../../redux/store';

function ShoppingListForm() {
    const dispatch = useDispatch()
    const selectedShoppingList = useSelector((state: RootState) => state.shoppingLists)
    const [shoppingList, setShoppingList] = useState<ShoppingList>({
        shoppingListId: '',
        name: '',
        recipes: [],
        ingredients: []
    })
    const [allShoppingLists, setAllShoppingLists] = useState<DropDownDataItem<ShoppingList>[]>([]);
    const [allRecipes, setAllRecipes] = useState<DropDownDataItem<Recipe>[]>([]);
    const [selectedRecipeIds, setSelectedRecipeIds] = useState<any>([]);

    useEffect(() => {
        agent.ShoppingLists.list().then(data => {
            if(data.length !== 0){
                 data.forEach(d => {
                    var dataObj = {
                        key: d.shoppingListId,
                        value: d.shoppingListId,
                        text: d.name
                    }
                    if (!allShoppingLists.find(i => i.key === dataObj.key)){
                        allShoppingLists.push(dataObj);
                    }
                })
                setAllShoppingLists(allShoppingLists);
            }
        })
        agent.Recipes.list().then(data => {
            if(data.length !== 0){
                data.forEach(d => {
                    var dataObj = {
                        key: d.recipeId,
                        value: d.recipeId,
                        text: d.name
                    }
                    if (!allRecipes.find(r => r.key === dataObj.key)){
                        allRecipes.push(dataObj);
                    }
                })
                setAllRecipes(allRecipes);
            }
        })
    }, [shoppingList, allShoppingLists, allRecipes, selectedRecipeIds])

    function handleSubmit(event: React.FormEvent<HTMLFormElement>, data: DropdownProps){
        event.preventDefault();

        dispatch(addRecipesToList(shoppingList.shoppingListId, selectedRecipeIds));
    }

    function handleShoppingListDropDownChange(event: SyntheticEvent<HTMLElement>, data: DropdownProps){
        dispatch(setSelectedShoppingList(data.value as string))
        setShoppingList({...shoppingList, [data.name]: data.value})
    }

    function handleRecipeDropDownChange(event: SyntheticEvent<HTMLElement>, data: DropdownProps){
        if (data?.value) {
            setSelectedRecipeIds(data.value);
        }
    }

    return (
        <Segment>
            <Form onSubmit={handleSubmit} autoComplete='off' >
                <Dropdown 
                    placeholder="Select a Shopping List" 
                    name="shoppingListId"
                    value={shoppingList.shoppingListId}
                    fluid
                    search
                    selection
                    clearable
                    options={allShoppingLists}
                    onChange={handleShoppingListDropDownChange} 
                />
                {shoppingList.shoppingListId !== '' && (
                <Dropdown 
                    placeholder="Select Recipes to Add to Shopping List" 
                    name="recipe"
                    multiple
                    fluid
                    selection
                    search
                    clearable
                    options={allRecipes}
                    onChange={handleRecipeDropDownChange}
                />
                )}
                <Button id="addRecipesBtn" floated="right" positive type="submit" content="Submit" />
            </Form>
        </Segment>
    )
}

export default ShoppingListForm;