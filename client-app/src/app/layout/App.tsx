import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container} from 'semantic-ui-react';
import { Recipe } from '../models/recipe';
import Navbar from './Navbar';
import RecipeDashboard from '../../features/recipes/dashboard/RecipeDashboard';

function App() {
  const[recipes, setRecipes] = useState<Recipe[]>([]);

  useEffect(() => {
    axios.get<Recipe[]>("http://localhost:8000/api/recipes").then(response => {
      console.log(response);
      setRecipes(response.data);
    })
  }, [])

  return (
    <Fragment>
      <Navbar />
      <Container style={{marginTop: '7em'}}>
        <RecipeDashboard 
          recipes={recipes}
        />
      </Container>
    </Fragment>
  );
}

export default App;
