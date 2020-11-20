import {UPLOAD_TYPE} from "@/data/enum";

const initState = () => ({
  submissions: []
});

export const state = initState;

export const mutations = {
  setExercises(state, {submissions}){
    state.submissions = submissions;
  },
  reset(state){
    Object.assign(state,initState())
  }
}

export const actions = {
  async fetchSubmissionsForExercise({commit}, {exerciseId}){
    const submissions =  await this.$axios.$get(`/api/exercises/${exerciseId}/submissions`)
    commit("setExercises", {submissions});
  },
  createSubmission({state, commit, dispatch}, {form}){
    return this.$axios.$post("/api/submissions", form)
  }
}
