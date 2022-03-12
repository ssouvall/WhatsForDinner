import React, { ChangeEvent, useState, useEffect, useCallback, useRef, SyntheticEvent } from "react";
import { Button, Dropdown, DropdownProps, Form, Segment } from "semantic-ui-react";
import { Recipe } from "../../../app/models/recipe";
import { useDispatch, useSelector } from 'react-redux';
import { createRecipe, editRecipe } from "../../../redux/actions/recipe/recipeActions";
import { RootState } from "../../../redux/store";
import { useHistory } from "react-router-dom";
import { v4 as uuid } from 'uuid';
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'
import agent from "../../../app/api/agent";
import { DropDownDataItem } from "../../../app/models/dropDownDataItem";
import { Ingredient } from "../../../app/models/ingredient";
import { IngredientListItem } from "../../../app/models/ingredientListItem";

export default function RecipeForm() {
    const dispatch = useDispatch()
    const history = useHistory()
    const [submitting, setSubmitting] = useState(false);
    const [ingredients, setIngredients] = useState<DropDownDataItem<Ingredient>[]>([]);
    let selectedRecipe: Recipe | undefined = useSelector((state: RootState) => state.recipes.recipe)
    let allRecipes: Recipe[] | undefined = useSelector((state: RootState) => state.recipes.recipes)

    const [recipe, setRecipe] = useState<Recipe>({
        id: '',
        name: '',
        category: '',
        description: '',
        instructions: '',
        ingredientListItems: []
    });

    const [ingredientSelection, setIngredientSelection] = useState<{ingredient:string}>({
        ingredient: ""
    });

    const [selectedIngredients, setSelectedIngredients] = useState<DropDownDataItem<Ingredient>[]>([]);

    useEffect(() => {
        if (selectedRecipe !== undefined) setRecipe(selectedRecipe)
        agent.Ingredients.list().then(data => {
            if(data.length !== 0){
                data.forEach(d => {
                    var dataObj = {
                        key: d.id,
                        value: d.name,
                        text: d.name
                    }
                    if (!ingredients.find(i => i.key === dataObj.key)){
                        ingredients.push(dataObj);
                    }
                })
                console.log(ingredients);
                setIngredients(ingredients);
            }
        })
    }, [selectedRecipe, ingredients])

    function handleLoading(submitting: boolean){
        setSubmitting(submitting);
    }

    function addRecipeIngredients(recipe: Recipe){
        if(selectedIngredients){
            selectedIngredients.forEach(ingredient => {
                var newIngredientItem: IngredientListItem = {
                    id: uuid(),
                    ingredientId: ingredient.key,
                    notes: "",
                    quantity: 1,
                    quantityUnit: "test unit",
                    recipeId: recipe.id,
                    isComplete: false
                }
                recipe.ingredientListItems.push(newIngredientItem);
            })
        }
    }

    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        event.stopPropagation();
        
        if(recipe){
            if(!allRecipes?.find(r => r.id === recipe.id)){
                recipe.id = uuid();
                addRecipeIngredients(recipe);
                dispatch(createRecipe(recipe));
                sweetAlertFire(true);
            } else {
                addRecipeIngredients(recipe);
                dispatch(editRecipe(recipe));
                sweetAlertFire(false);
            }
        }
        history.push('/recipes');
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLTextAreaElement>) {
        const {name, value} = event.target;
        setRecipe({...recipe, [name]: value}) 
    }

    function handleDropDownChange(event: SyntheticEvent<HTMLElement>, data: DropdownProps){
        setIngredientSelection({...ingredientSelection, [data.name]: data.value})
        var dataKey = (data.options?.find(o => o.value === data.value))?.key
        if(data.value !== "" && dataKey && !selectedIngredients.find(i => i.key === dataKey)){
            var newIngredientItem: DropDownDataItem<Ingredient> = {
                key: dataKey,
                value: data.value as string,
                text: data.text as string
            }
            selectedIngredients.push(newIngredientItem);
            setSelectedIngredients(selectedIngredients);
        }
    }

    function sweetAlertFire(isNewRecipe: boolean){
        const MySwal = withReactContent(Swal)

        MySwal.fire({
        title: <p>Recipe Confirmed</p>,
        footer: 'Copyright 2018',
        didOpen: () => {
            // `MySwal` is a subclass of `Swal`
            //   with all the same instance & static methods
            MySwal.clickConfirm()
        }
        }).then(() => {
            if(isNewRecipe){
                return MySwal.fire(<p>Recipe Added</p>)
            } else {
                return MySwal.fire(<p>Recipe Updated</p>)
            }
        })
    }

    var displayRecipeIngredients = selectedIngredients.map((ingredient) => (
        <div>
            {ingredient.value}
            <Button content="X" />
        </div>
    ));

    // if(!submitted){
        return (
            <Segment clearing>
                <Form onSubmit={handleSubmit} autoComplete='off' >
                    <Form.Input placeholder="Title" value={recipe.name} name='name' onChange={handleInputChange} />
                    <Form.TextArea placeholder="Description" value={recipe.description} name='description' onChange={handleInputChange} />
                    <Form.Input placeholder="Category" value={recipe.category} name='category' onChange={handleInputChange} />
                    <Form.TextArea placeholder="Instructions" value={recipe.instructions} name='instructions' onChange={handleInputChange} />
                    {/* <SampleModal 
                        submitting={submitting}
                        recipe={recipe}
                    /> */}
                    <Dropdown 
                        placeholder="Ingredient " 
                        name="ingredient"
                        value={ingredientSelection.ingredient}
                        fluid
                        search
                        selection
                        options={ingredients}
                        onChange={handleDropDownChange} 
                        />
                    {displayRecipeIngredients}
                    <Button loading={submitting} floated="right" positive type="submit" content="Submit" />
                    {/* <Button onClick={closeForm} floated="right" type="submit" content="Cancel" /> */}
                    {/* <Button as={Link} to='/recipes' onClick={() => dispatch(setFormOpenState(false, recipe))} floated="right" type="submit" content="Cancel" /> */}
                </Form>
            </Segment>
        )
    // } else {
    //     return (
    //         <Redirect to={`/recipes/${recipe.id}`} />
    //     )
    // }
    
}