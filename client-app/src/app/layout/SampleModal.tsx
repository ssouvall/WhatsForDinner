import React from 'react'
import { Button, Header, Modal } from 'semantic-ui-react'
import { Link } from "react-router-dom";
import { Recipe } from '../models/recipe';

export interface Props {
  submitting: boolean;
  recipe: Recipe;
}

function ModalExampleBasic({submitting, recipe}:Props) {
  const [open, setOpen] = React.useState(false)
  return (
    <Modal
      onClose={() => setOpen(false)}
      onOpen={() => {setOpen(true)}}
      open={open}
      size='small'
      trigger={<Button loading={submitting} floated="right" positive type="submit" content="Submit" />}
    >
      <Modal.Header>All set!</Modal.Header>
      <Modal.Content image>
        <Modal.Description>
          <h3>
            Your recipe has been created.          
          </h3>
        </Modal.Description>
      </Modal.Content>
      <Modal.Actions>
        {/* <Button 
          as={Link} 
          to='/recipes' 
          color='red' 
          onClick={() => setOpen(false)}
          content='Back to List'
        /> */}
        <Button
          as={Link} 
          to='/recipes'
          content="Ok!"
          labelPosition='right'
          icon='checkmark'
          onClick={() => setOpen(false)}
          positive
        />
      </Modal.Actions>
    </Modal>
  )
}

export default ModalExampleBasic
