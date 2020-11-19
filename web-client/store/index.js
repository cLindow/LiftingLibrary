﻿import Axios from "axios";

const initState = () => ({})

export const state = initState

export const mutations = {
  reset(state){
    Object.assign(state, initState())
  }
}

export const actions = {
  async nuxtServerInit({commit, dispatch}){
    await dispatch("exercises/fetchExercises")
    await dispatch("submissions/fetchSubmissions")
  }
}
