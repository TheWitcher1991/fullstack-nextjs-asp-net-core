import { create } from 'zustand/index'

import { ITopicBooks, UseBooks } from '~models/book'

import {
	createModelListReducer,
	CreateModelListReducerState,
} from '~packages/reducers'

export const useBooksByTopicStore = create<
	CreateModelListReducerState<ITopicBooks, Partial<UseBooks>>
>((...a) =>
	createModelListReducer<ITopicBooks, Partial<UseBooks>>(
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
