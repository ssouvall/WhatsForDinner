import React, { Fragment } from 'react';
import { Container} from 'semantic-ui-react';
import Navbar from './Navbar';
import HomePage from '../../features/home/HomePage';
import { Route, useLocation } from 'react-router-dom';
import RecipeDashboard from '../../features/recipes/dashboard/RecipeDashboard';
import RecipeForm from '../../features/recipes/form/RecipeForm';
import RecipeDetails from '../../features/recipes/details/RecipeDetails';
import IngredientDashboard from '../../features/ingredients/dashboard/IngredientDashboard';
import IngredientDetails from '../../features/ingredients/details/IngredientDetails';
import IngredientForm from '../../features/ingredients/form/IngredientForm';
import ShoppingListDashboard from '../../features/shoppingLists/dashboard/ShoppingListDashboard';

function App() {
  const location = useLocation();
  return (
    <Fragment>
      <Navbar />
      <Container>
        <Route exact path='/' component={HomePage} />
        <Route exact path='/recipes' component={RecipeDashboard} />
        <Route exact path='/recipes/:id' component={RecipeDetails} />
        <Route key={location.key} path={['/createRecipe', '/manage/:id']} component={RecipeForm} />
        <Route exact path='/ingredients' component={IngredientDashboard} />
        <Route exact path='/ingredients/:id' component={IngredientDetails} />
        <Route exact path='/shoppingLists' component={ShoppingListDashboard} />
      </Container>
    </Fragment>
  );
}

export default App;
