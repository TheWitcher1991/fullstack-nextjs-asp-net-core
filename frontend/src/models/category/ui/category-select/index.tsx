'use client'

import { Select, Skeleton } from '@gravity-ui/uikit'
import { FieldPath, UseFormRegister } from 'react-hook-form'

import { useSelectableCategories } from '~models/category'

interface CategorySelectProps<T = any> {
	defaultValue?: string[]
	value?: string[]
	errorMessage?: string
	onSelect: (value: string[]) => void
	register: UseFormRegister<T>
}

export function CategorySelect<T = any>({
	defaultValue,
	value,
	errorMessage,
	onSelect,
	register,
}: CategorySelectProps<T>) {
	const { isLoading, categories } = useSelectableCategories()

	return isLoading ? (
		<Skeleton
			style={{
				height: 35,
			}}
		/>
	) : (
		<>
			<Select
				defaultValue={defaultValue || []}
				value={value || []}
				hasClear={true}
				name={'categories'}
				ref={register('categories' as FieldPath<T>).ref}
				errorMessage={errorMessage}
				width={'max'}
				size={'l'}
				filterable={true}
				placeholder={'Выберите категорию'}
				options={categories}
				validationState={errorMessage ? 'invalid' : undefined}
				onUpdate={onSelect}
			/>
		</>
	)
}
