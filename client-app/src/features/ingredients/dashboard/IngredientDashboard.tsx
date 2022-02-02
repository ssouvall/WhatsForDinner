import React, {useState, useEffect} from "react";
import { Grid} from "semantic-ui-react";
import { Ingredient } from "../../../app/models/ingredient";
import IngredientForm from "../form/IngredientForm";
import IngredientList from "./IngredientList";
import {useDispatch, useSelector} from 'react-redux';
import { RootState } from "../../../redux/store";
import { fetchIngredients } from "../../../redux/actions/ingredient/ingredientActions";
import LoadingComponent from '../../../app/layout/LoadingComponents';

function IngredientDashboard(){
    const [state, setState] = useState({});
    const[ingredients,setIngredients] = useState<Ingredient[]>([]);
    const [loading, setLoading] = useState(true);
    const dispatch = useDispatch()
    const allIngredients: Ingredient[] = useSelector((state: RootState) => state.ingredients.ingredients)

    useEffect(() => {
      function loadIngredientData(){
        return new Promise ((resolve, reject) => {
          resolve(dispatch(fetchIngredients()));
          reject('There was an error loading the data');
        })
      }
      loadIngredientData().then(data => {
        setTimeout(() => {
          setIngredients(data as Ingredient[]);
          setLoading(false);
        }, 1000)
      })
      return () => {
        setState({}); 
    };
    }, [dispatch, allIngredients])

    if (loading) return <LoadingComponent content='Loading...' />

    return(
        <Grid>
            <Grid.Column width='10'>
                <IngredientList />
            </Grid.Column>
            <Grid.Column width='6'>
                <h2>Add Ingredients</h2>
                <IngredientForm />
            </Grid.Column>
        </Grid>
    )
}

export default IngredientDashboard;