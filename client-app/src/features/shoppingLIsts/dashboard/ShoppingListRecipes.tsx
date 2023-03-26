import React, { useEffect, useState } from 'react';
import { Recipe } from '../../../app/models/recipe';
import { useDispatch, useSelector } from 'react-redux';
import { fetchRecipesByShoppingList } from '../../../redux/actions/shoppingList/shoppingListActions';
import { RootState } from '../../../redux/store';
import { Segment } from 'semantic-ui-react';

function ShoppingListRecipes() {
    const dispatch = useDispatch()
    const [shoppingListRecipes, setShoppingListRecipes] = useState<Recipe[]>([]);
    const selectedShoppingList = useSelector((state: RootState) => state.shoppingLists.selectedShoppingList)
    const recipeList = useSelector((state: RootState) => state.shoppingLists.shoppingListRecipes)

    useEffect(() => {
        if (selectedShoppingList) {
            dispatch(fetchRecipesByShoppingList(selectedShoppingList));
        }
        if (recipeList) {
           setShoppingListRecipes(recipeList);
        }
    }, [dispatch, recipeList, selectedShoppingList])

    return(
        <Segment>
            {shoppingListRecipes && (
                shoppingListRecipes.map((recipe: Recipe) => (
                    <div>
                        <h3>{recipe.name}</h3>
                        <p>{recipe.description}</p>
                    </div>
                ))
            )}
        </Segment>
    )
}

export default ShoppingListRecipes;