import React from "react";
import { Button, Container, Menu } from "semantic-ui-react";
import { useDispatch } from 'react-redux';
import { setFormOpenState } from '../../redux/actions/recipe/recipeActions';
import { NavLink } from "react-router-dom"

export default function Navbar() {
    const dispatch = useDispatch();

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' exact header>
                    <img src="/assets/utensils-solid.svg" alt="logo" style={{marginRight: '10px'}}/>
                    What's For Dinner?
                </Menu.Item>
                <Menu.Item as={NavLink} to='/recipes' name="Recipes" />
                <Menu.Item as={NavLink} to='/ingredients' name="Ingredients" />
                <Menu.Item>
                    <Button id='createBtn' as={NavLink} to='/createRecipe' onClick={() => dispatch(setFormOpenState(true, undefined))} content="Create Recipe" />
                </Menu.Item>
            </Container>
        </Menu>
    )
}