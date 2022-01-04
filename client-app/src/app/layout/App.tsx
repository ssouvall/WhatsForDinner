import React, { Fragment } from 'react';
import { Container} from 'semantic-ui-react';
import Navbar from './Navbar';
import HomePage from '../../features/home/HomePage';
import { Route, useLocation } from 'react-router-dom';
import RecipeDashboard from '../../features/recipes/dashboard/RecipeDashboard';
import RecipeForm from '../../features/recipes/form/RecipeForm';
import RecipeDetails from '../../features/recipes/details/RecipeDetails';

function App() {
  const location = useLocation();
  return (
    <Fragment>
      <Navbar />
      <Container style={{marginTop: '7em'}}>
        <Route exact path='/' component={HomePage} />
        <Route exact path='/recipes' component={RecipeDashboard} />
        <Route exact path='/recipes/:id' component={RecipeDetails} />
        <Route key={location.key} path={['/createRecipe', '/manage/:id']} component={RecipeForm} />
      </Container>
    </Fragment>
  );
}

export default App;
