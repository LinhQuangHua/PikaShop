import React, { useState } from "react";
import axios from 'axios';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useSelector } from "react-redux";
import { selectUser } from "../../store/auth-slice";

export default () => {
    const [nameCate , setName] = useState('');

    const user = useSelector(selectUser);


    const handleChange = (event: any) => {
        setName(event.target.value);
    }

    const handleSubmit = (event: any) => {
        event.preventDefault();
        
        axios.post(
                `https://pikashop.azurewebsites.net/api/category`, 
                { name_category: nameCate }, 
                { headers: {"Authorization" : `Bearer ${user?.token}`},
            }).then(res => {
                console.log(res.data);
            }).catch(err => {
                console.log(err);
            })
    }

        return (
            <>
                <br/>
                <h5>Add new category</h5>
                <Form inline onSubmit={handleSubmit}>
                    <FormGroup className="mb-2 mr-sm-2 mb-sm-0">
                        <Label for="exampleEmail" className="mr-sm-2">Name</Label>
                        <Input type="text" value={nameCate} placeholder="New category..." onChange={handleChange}/>
                    </FormGroup>
                    <Button type="submit">Add</Button>
                </Form>
                <hr/>
            </>
        )
}

