import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container} from 'semantic-ui-react';
import { Recipe } from '../models/recipe';
import Navbar from './Navbar';
import RecipeDashboard from '../../features/recipes/dashboard/RecipeDashboard';

function App() {
  const[recipes, setRecipes] = useState<Recipe[]>([]);
  const [selectedRecipe, setSelectedRecipe] = useState<Recipe | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);
  const [submitting, setSubmitting] = useState(false);

  useEffect(() => {
    axios.get<Recipe[]>("http://localhost:8000/api/recipes").then(response => {
      console.log(response);
      setRecipes(response.data);
    })
  }, [])

  function handleSelectRecipe(id: number) {
    setSelectedRecipe(recipes.find(x => x.id === id));
  }

  function handleCancelSelectRecipe() {
    setSelectedRecipe(undefined);
  }

  function handleFormOpen(id?: number) {
    id ? handleSelectRecipe(id) : handleCancelSelectRecipe();
    setEditMode(true);
  }
  
  function handleFormClose() {
    setEditMode(false);
  }

  function handleCreateOrEditRecipe(recipe: Recipe) {
    setSubmitting(true);
    if (recipe.id) {
      axios.put<Recipe>(`http://localhost:8000/api/recipes/${recipe.id}`).then(() => {
        setRecipes([...recipes.filter(x => x.id !== recipe.id), recipe])
        setSelectedRecipe(recipe);
        setEditMode(false)
        setSubmitting(false);
      })
    } else {
      axios.post<Recipe>("http://localhost:8000/api/recipes").then(() => {
        setRecipes([...recipes, recipe])
        setSelectedRecipe(recipe);
        setEditMode(false);
        setSubmitting(false);
      })
    }
  }

  return (
    <Fragment>
      <Navbar 
        openForm={handleFormOpen}
      />
      <Container style={{marginTop: '7em'}}>
        <RecipeDashboard 
          recipes={recipes}
          selectedRecipe={selectedRecipe}
          selectRecipe={handleSelectRecipe}
          cancelSelectRecipe={handleCancelSelectRecipe}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          editMode={editMode}
          createOrEdit={handleCreateOrEditRecipe}
          submitting={submitting}
        />
      </Container>
    </Fragment>
  );
}

export default App;
