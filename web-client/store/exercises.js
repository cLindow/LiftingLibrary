import Axios from "axios";

const initState = () => ({
  exercises: []
});

export const state = initState;

export const mutations = {
  setExercises(state, {exercises}){
    state.exercises = exercises;
  },
  reset(state){
    Object.assign(state,initState())
  }
}

export const actions = {
  async fetchExercises({commit}){
    const exercises =  ( await Axios.get("http://localhost:5000/api/exercises")).data;
    commit("setExercises", {exercises});
  },
  async createExercise({commit, dispatch}, {exercise}){
    await Axios.post("http://localhost:5000/api/exercises", exercise)
    await dispatch('fetchExercises')
  }
}
