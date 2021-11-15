import React from "react";
import { Button, Container, Menu } from "semantic-ui-react";

interface Props {
    openForm: () => void;
}

export default function Navbar({openForm}: Props) {
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header>
                    <img src="/assets/logo.png" alt="logo" style={{marginRight: '10px'}}/>
                    What's For Dinner?
                </Menu.Item>
                <Menu.Item name="Recipes" />
                <Menu.Item>
                    <Button onClick={openForm} positive content="Create Recipe" />
                </Menu.Item>
            </Container>
        </Menu>
    )
}