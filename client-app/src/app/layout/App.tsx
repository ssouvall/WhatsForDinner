import React, { Fragment, useEffect, useState } from 'react';
import { Container} from 'semantic-ui-react';
import { Recipe } from '../models/recipe';
import Navbar from './Navbar';
import RecipeDashboard from '../../features/recipes/dashboard/RecipeDashboard';
import agent from '../api/agent';
import LoadingComponent from './LoadingComponents';

function App() {
  const[recipes, setRecipes] = useState<Recipe[]>([]);
  const [selectedRecipe, setSelectedRecipe] = useState<Recipe | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);
  const [submitting, setSubmitting] = useState(false);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    agent.Recipes.list().then(response => {
      setRecipes(response);
      setLoading(false);
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
      agent.Recipes.update(recipe).then(() => {
        setRecipes([...recipes.filter(x => x.id !== recipe.id), recipe])
        setSelectedRecipe(recipe);
        setEditMode(false)
        setSubmitting(false);
      })
    } else {
      agent.Recipes.create(recipe).then(() => {
        setRecipes([...recipes, recipe])
        setSelectedRecipe(recipe);
        setEditMode(false);
        setSubmitting(false);
      })
    }
  }

    function handleDeleteRecipe(id: number) {
    setSubmitting(true);
    agent.Recipes.delete(id).then(() => {
      setRecipes([...recipes.filter(x => x.id !== id)])
      setSubmitting(false);
    })
  }
  
  if (loading) return <LoadingComponent content='Loading app' />

  return (
    <Fragment>
      <Navbar 
        openForm={handleFormOpen}
      />
      <Container style={{marginTop: '7em'}}>
        <RecipeDashboard 
          selectedRecipe={selectedRecipe}
          selectRecipe={handleSelectRecipe}
          cancelSelectRecipe={handleCancelSelectRecipe}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          editMode={editMode}
          createOrEdit={handleCreateOrEditRecipe}
          deleteRecipe={handleDeleteRecipe}
          submitting={submitting}
        />
      </Container>
    </Fragment>
  );
}

export default App;
