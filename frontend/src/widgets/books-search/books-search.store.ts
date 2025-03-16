import { create } from 'zustand'

import { IBook, UseBooks } from '~models/book'

import {
	createModelListReducer,
	CreateModelListReducerState,
} from '~packages/reducers'

export const useBooksSearchStore = create<
	CreateModelListReducerState<IBook, Partial<UseBooks>>
>((...a) =>
	createModelListReducer<IBook, Partial<UseBooks>>(
		{
			count: 0,
			list: [],
			meta: {},
			checked: [],
			loading: true,
			filter: {
				page: 1,
				pageSize: 20,
			},
		},
		...a,
	),
)
