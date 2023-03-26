import React from "react";
import { Container, Header, Segment, Image, Button } from "semantic-ui-react";
import { Link } from "react-router-dom";

export default function HomePage() {
    return (
        <Segment textAlign="center" vertical className='masthead'>
            <Image size='massive' src='/assets/homepage-hero.jpg' alt='hero' style={{objectFit: 'cover', width: '100%', height: '100%',  position: 'relative'}} />
            <Container text style={{background: 'rgba(0,0,0,.5)', padding: '7%', position:'absolute', width: '60%', left: '20%', right: '20%'}}>
                <Header as='h1' inverted>
                    <Image size='massive' src='/assets/utensils-solid.svg' alt='logo' style={{marginBottom: 12}} />
                    What's For Dinner
                </Header>
                <Header as='h2' content="Welcome to What's For Dinner" inverted />
                <Button as={Link} to='/recipes' size='huge'>
                    Take me to the Recipes!
                </Button>
            </Container>
        </Segment>
    )
}