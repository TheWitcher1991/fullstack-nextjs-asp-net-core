export type CreateModelListReducerState<
	T,
	U extends Record<string, any>,
	M extends Record<string, any> = Record<string, any>,
> = ModelListState<T, U, M>

export const createModelListReducer = <
	T,
	U extends Record<string, any>,
	M extends Record<string, any> = Record<string, any>,
>(
	initialState: ModelListField<T, U, M>,
	set,
	..._args
): CreateModelListReducerState<T, U, M> => ({
	...initialState,
	setCount: count => set({ count }),
	setList: list => set({ list }),
	setMeta: meta => set({ meta }),
	setFilter: filter =>
		set(state => ({ filter: { ...state.filter, ...filter } })),
	setLoading: loading => set({ loading }),
	setChecked: checked => set({ checked }),
	setFetching: fetching => set({ fetching }),
	reset: () =>
		set({
			filter: initialState.filter,
		}),
})

export type ModelListReducerType<
	T,
	U extends Record<string, any>,
	M extends Record<string, any> = Record<string, any>,
> = ReturnType<typeof createModelListReducer<T, U, M>>

export type CreateModelReducerState<T = Record<string, any>> = {
	model: T
	setModel: (model: Partial<T>) => void
}

export const createModelReducer = <T>(
	initialState: T,
	set,
	..._args
): CreateModelReducerState<T> => ({
	model: initialState,
	setModel: model => set(state => ({ model: { ...state.model, ...model } })),
})

export type ModelReducerType<T> = ReturnType<typeof createModelReducer<T>>
