import { create } from 'zustand'

import { ITopic, UseTopics } from '~models/topic'

import {
	createModelListReducer,
	CreateModelListReducerState,
} from '~packages/reducers'

export const useTopicsMostStore = create<
	CreateModelListReducerState<ITopic, Partial<UseTopics>>
>((...a) =>
	createModelListReducer<ITopic, Partial<UseTopics>>(
		{
			count: 0,
			list: [],
			meta: {},
			checked: [],
			loading: true,
			filter: {},
		},
		...a,
	),
)
