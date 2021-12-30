import React from "react";
import { Button, Container, Menu } from "semantic-ui-react";
import { useDispatch } from 'react-redux';
import { setFormOpenState } from '../../redux/actions/recipe/recipeActions';

interface Props {
    openForm: () => void;
}

export default function Navbar({openForm}: Props) {
    const dispatch = useDispatch();

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header>
                    <img src="/assets/logo.png" alt="logo" style={{marginRight: '10px'}}/>
                    What's For Dinner?
                </Menu.Item>
                <Menu.Item name="Recipes" />
                <Menu.Item>
                    <Button onClick={() => dispatch(setFormOpenState(true, undefined))} positive content="Create Recipe" />
                </Menu.Item>
            </Container>
        </Menu>
    )
}