import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import agent from '../../../app/api/agent';
import { Recipe } from '../../../app/models/recipe'

interface RecipeState {
    recipes: Recipe[];
}

const initialState: RecipeState = {
    recipes: []
}

export const getRecipesAsync = createAsyncThunk(
	'recipes/getRecipesAsync',
	async () => {
		await agent.Recipes.list()
        .then(response => {
            const recipes: Recipe[] = response;
            return { recipes };
        })
	}
);

export const recipeSlice = createSlice({
	name: 'recipes',
	initialState,
	reducers: {
        getRecipes(state, action: PayloadAction<any>){
            // state.recipes.push(action.payload);
            return action.payload;
        }
		// addTodo: (state, action) => {
		// 	const todo = {
		// 		id: nanoid(),
		// 		title: action.payload.title,
		// 		completed: false,
		// 	};
		// 	state.push(todo);
		// },
		// toggleComplete: (state, action) => {
		// 	const index = state.findIndex((todo) => todo.id === action.payload.id);
		// 	state[index].completed = action.payload.completed;
		// },
		// deleteTodo: (state, action) => {
		// 	return state.filter((todo) => todo.id !== action.payload.id);
		// },
	},
	// extraReducers: {
	// 	[getRecipesAsync.fulfilled]: (state: RecipeState, action: PayloadAction<Recipe[]>) => {
    //         let newArr = state.recipes.push(action.payload);
    //         return newArr;
	// 	},
	// 	// [addTodoAsync.fulfilled]: (state, action) => {
	// 	// 	state.push(action.payload.todo);
	// 	// },
	// 	// [toggleCompleteAsync.fulfilled]: (state, action) => {
	// 	// 	const index = state.findIndex(
	// 	// 		(todo) => todo.id === action.payload.todo.id
	// 	// 	);
	// 	// 	state[index].completed = action.payload.todo.completed;
	// 	// },
	// 	// [deleteTodoAsync.fulfilled]: (state, action) => {
	// 	// 	return state.filter((todo) => todo.id !== action.payload.id);
	// 	// },
	// },
});

 export const { getRecipes/*addTodo, toggleComplete, deleteTodo*/ } = recipeSlice.actions;

export default recipeSlice.reducer;
