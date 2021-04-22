import React from "react";
import axios from 'axios';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

export default class PostCategory extends React.Component {
    state = {
        name_cate: ''
    }

    handleChange = (event: any) => {
        this.setState({ name_cate: event.target.value });
    }

    handleSubmit = (event: any) => {
        event.preventDefault();

        const brand = {
            name_cate: this.state.name_cate
        };

        axios.post(`https://localhost:44317/api/category`, { brand })
            .then(res => {
                console.log(res);
                console.log(res.data);
            })
    }

    render() {
        return (
            <>
            <br/>
            <h5>Add new category</h5>
            <Form inline onSubmit={this.handleSubmit}>
                <FormGroup className="mb-2 mr-sm-2 mb-sm-0">
                    <Label for="exampleEmail" className="mr-sm-2">Name</Label>
                    <Input type="text" name="name_brand" placeholder="New category..." onChange={this.handleChange}/>
                </FormGroup>
                <Button type="submit">Add</Button>
            </Form>
            <hr/>
            </>
        )
    }
}

