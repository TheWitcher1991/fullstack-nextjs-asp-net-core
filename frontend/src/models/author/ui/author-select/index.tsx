'use client'

import { Select, Skeleton } from '@gravity-ui/uikit'
import { FieldPath, UseFormRegister } from 'react-hook-form'

import { useSelectableAuthors } from '~models/author'

interface AuthorSelectProps<T = any> {
	defaultValue?: string[]
	value?: string[]
	errorMessage?: string
	onSelect: (value: string[]) => void
	register: UseFormRegister<T>
}

export function AuthorSelect<T = any>({
	defaultValue,
	value,
	errorMessage,
	onSelect,
	register,
}: AuthorSelectProps<T>) {
	const { isLoading, authors } = useSelectableAuthors()

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
				name={'authors'}
				ref={register('authors' as FieldPath<T>).ref}
				errorMessage={errorMessage}
				width={'max'}
				size={'l'}
				filterable={true}
				placeholder={'Выберите автора'}
				options={authors}
				validationState={errorMessage ? 'invalid' : undefined}
				onUpdate={onSelect}
			/>
		</>
	)
}
