import React, {SyntheticEvent, useState} from "react";
import { useDispatch, useSelector } from 'react-redux';
import { Button, Item, Label, Segment } from "semantic-ui-react";
import { Ingredient } from "../../../app/models/ingredient";
import { deleteIngredient, setIngredientDetails } from "../../../redux/actions/ingredient/ingredientActions";
import { RootState } from "../../../redux/store";
import { Link } from "react-router-dom";

function IngredientList(){
    const dispatch = useDispatch()
    const [submitting, setSubmitting] = useState(false);
    const [loading, setLoading] = useState(false);
    const [target, setTarget] = useState('');
    const ingredients: Ingredient[] = useSelector((state: RootState) => state.ingredients.ingredients)

    function setIngredientToShow(e: SyntheticEvent<HTMLButtonElement>, ingredientId: string){
        console.log(e.currentTarget)
        setTarget(e.currentTarget.name)
        setLoading(true);
        // await dispatch(setFormOpenState(false, undefined));
        dispatch(setIngredientDetails(ingredientId));
        setTimeout(() => {
            setLoading(false);
        }, 1000)
    }

    async function deleteSelectedIngredient(e: SyntheticEvent<HTMLButtonElement>, ingredientId: string){
        var targetIngredient: Ingredient | undefined = ingredients.find(r => r.id === ingredientId);
        await setTarget(e.currentTarget.name)
        await setSubmitting(true);
        await dispatch(deleteIngredient(ingredientId));
        // await setTimeout(() => {
        //     setSubmitting(false);
        // }, 1000)
        if(targetIngredient && !ingredients.includes(targetIngredient)){
            setSubmitting(false);
        }
    }

    return(
        <Segment>
            <Item.Group divided>
                {ingredients.map((ingredient) => (
                    <Item key={ingredient.id}>
                        <Item.Content>
                            <Item.Header as='a'>{ingredient.name}</Item.Header>
                            <Item.Extra>
                                <Button as={Link} to={`/ingredients/${ingredient.id}`} 
                                    onClick={(e) => setIngredientToShow(e, ingredient.id)}
                                    name={ingredient.id}
                                    loading={loading && target === ingredient.id.toString()}
                                    floated='right' 
                                    content='View' 
                                    color='green' />
                                <Button 
                                    name={ingredient.id}
                                    onClick={(e) => deleteSelectedIngredient(e, ingredient.id)} 
                                    loading={submitting && target === ingredient.id.toString()}
                                    floated='right' 
                                    content='Delete' 
                                    color='orange' 
                                />
                                <Label basic content={ingredient.category}/>
                            </Item.Extra>
                        </Item.Content>
                    </Item>     
            ))}
            </Item.Group>
        </Segment>
    );
}

export default IngredientList;