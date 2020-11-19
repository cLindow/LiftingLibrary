import {UPLOAD_TYPE} from "@/data/enum";

const initState = () => ({
  uploadPromise: null,
  active: false,
  type: "",
  tabIndex: 0
});



export const state = initState;

export const mutations = {
  toggleActive(state) {
    state.active = !state.active
    if(!state.active){
      Object.assign(state, initState())
    }
  },
  setType(state, {type}) {
    state.type = type

    if(type === UPLOAD_TYPE.EXERCISE) {
      state.tabIndex++
    }
    else if(type === UPLOAD_TYPE.SUBMISSION) {
      state.tabIndex +=2;
    }

  },
  setTask(state, {uploadPromise}){
    state.uploadPromise = uploadPromise;
    state.tabIndex++
  },
  incTab(state){
    state.tabIndex++;
  },
  reset(state){
    Object.assign(state,initState())
  }
}

export const actions = {
  startVideoUpload({commit, dispatch}, {form}){
    const uploadPromise = this.$axios.$post("/api/videos", form);
    commit("setTask", {uploadPromise})
  },
  async createExercise({state, commit, dispatch}, {exercise, submission}){
    if(state.type === UPLOAD_TYPE.EXERCISE) {
      const createdExercise = await this.$axios.$post("/api/exercises", exercise)
      submission.exerciseId = createdExercise.id
    }
    const createdSubmission = await this.$axios.$post("/api/submissions", submission)

    await dispatch('exercises/fetchExercises', null, {root:true})
    await dispatch('submissions/fetchSubmissions', null, {root:true})
  }
}
